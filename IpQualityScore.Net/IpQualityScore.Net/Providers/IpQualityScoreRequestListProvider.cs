using AutoMapper;
using IpQualityScore.Common.Queries;
using IpQualityScore.Common.Responses;
using IpQualityScore.Common;
using IpQualityScore.Net.Providers.Contract;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Providers.Common;
using IpQualityScore.Net.Results;
using IpQualityScore.Net.Results.Common;
using IpQualityScore.Common.Responses.Common;

namespace IpQualityScore.Net.Providers
{
	internal class IpQualityScoreRequestListProvider : IpQualityScoreBaseProvider, IIpQualityScoreRequestListProvider
	{
		private readonly IMapper _mapper;
		private readonly IIpQualityScoreApiClient _ipQualityScoreApiClient;

		public IpQualityScoreRequestListProvider(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<IpQualityScoreRequestApiRequest, IpQualityScoreRequestApiQuery>()
				.ForMember("Type", opt => opt.MapFrom(c => c.Type.ToString()))
				.ForMember("StartDate", opt => opt.MapFrom(c => c.StartDate.ToString("yyyy-MM-dd HH:mm:ss")))
				.ForMember("StopDate", opt => opt.MapFrom(c => c.StopDate.ToString("yyyy-MM-dd HH:mm:ss")))
				.ForMember("CustomVariables", opt => opt.MapFrom(c => c.CustomVariables.ToDictionary(cv => cv.Key, cv => cv.Value.ToString())));
				cfg.CreateMap(typeof(IpQualityScoreRequestApiResponse<>), typeof(IpQualityScoreRequestApiResult<>));

				cfg.CreateMap<TransactionScoringResponse, TransactionRiskScoringResult>();
				cfg.CreateMap<EmailValidationResponse, EmailValidationResult>();
				cfg.CreateMap<AssociatedNameResponse, AssociatedName>();
				cfg.CreateMap<AssociatedPhoneNumberResponse, AssociatedPhoneNumber>();
				cfg.CreateMap<DomainAgeResponse, DomainAge>();
				cfg.CreateMap<EmailValidationFirstSeenResponse, EmailFirstSeen>();
			});
			_mapper = mapperConfig.CreateMapper();
			_ipQualityScoreApiClient = ipQualityScoreApiClient;
		}

		public async Task<IpQualityScoreRequestApiResult<TType>> Get<TType>(IpQualityScoreRequestApiRequest request)
			where TType: IpQualityScoreRequestResult, new()
		{
			if (request == null)
				throw new ArgumentException(null, nameof(request));
			ValidateRequest<IpQualityScoreRequestApiRequestValidator, IpQualityScoreRequestApiRequest>(request);

			var query = _mapper.Map<IpQualityScoreRequestApiQuery>(request);
			if (request.Type == IpQualityScoreRequestType.Proxy)
			{
				var response = await _ipQualityScoreApiClient.Get<IpQualityScoreRequestApiQuery, IpQualityScoreRequestApiResponse<TransactionScoringResponse>>(query, new string[] { "list" });
				var result = _mapper.Map<IpQualityScoreRequestApiResponse<TransactionScoringResponse>, IpQualityScoreRequestApiResult<TType>>(response);
				return result;
			}
			else if (request.Type == IpQualityScoreRequestType.Email)
			{
				var response = await _ipQualityScoreApiClient.Get<IpQualityScoreRequestApiQuery, IpQualityScoreRequestApiResponse<EmailValidationResponse>>(query, new string[] { "list" });
				var result = _mapper.Map<IpQualityScoreRequestApiResponse<EmailValidationResponse>, IpQualityScoreRequestApiResult<TType>>(response);
				return result;
			}
			else
				throw new ArgumentException($"Request type {request.Type} not supported");
		}
	}
}
