using AutoMapper;
using IpQualityScore.Common.Queries;
using IpQualityScore.Common.Responses;
using IpQualityScore.Common;
using IpQualityScore.Net.Providers.Contract;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using IpQualityScore.Net.Providers.Common;

namespace IpQualityScore.Net.Providers
{
	internal class IpQualityScoreRequestsProvider : IpQualityScoreBaseProvider, IIpQualityScoreRequestsProvider
	{
		private readonly IMapper _mapper;
		private readonly IIpQualityScoreApiClient _ipQualityScoreApiClient;

		public IpQualityScoreRequestsProvider(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<IpQualityScoreRequestApiRequest, IpQualityScoreRequestApiQuery>()
				.ForMember("Type", opt => opt.MapFrom(c => c.Type.ToString()))
				.ForMember("StartDate", opt => opt.MapFrom(c => c.StartDate.ToString("yyyy-MM-dd HH:mm:ss")))
				.ForMember("StopDate", opt => opt.MapFrom(c => c.StopDate.ToString("yyyy-MM-dd HH:mm:ss")))
				.ForMember("CustomVariables", opt => opt.MapFrom(c => c.CustomVariables.ToDictionary(cv => cv.Key, cv => cv.Value.ToString())));
				cfg.CreateMap<IpQualityScoreRequestApiResponse, IpQualityScoreRequestApiResult>();
				cfg.CreateMap<IpQualityScoreApiRequest, IpQualityScoreRequest>();
			});
			_mapper = mapperConfig.CreateMapper();
			_ipQualityScoreApiClient = ipQualityScoreApiClient;
		}

		public async Task<IpQualityScoreRequestApiResult> Get(IpQualityScoreRequestApiRequest request)
		{
			if (request == null)
				throw new ArgumentException(null, nameof(request));
			ValidateRequest<IpQualityScoreRequestApiRequestValidator, IpQualityScoreRequestApiRequest>(request);

			var query = _mapper.Map<IpQualityScoreRequestApiQuery>(request);
			var response = await _ipQualityScoreApiClient.Get<IpQualityScoreRequestApiQuery, IpQualityScoreRequestApiResponse>(query, new string[] { "list" });
			var result = _mapper.Map<IpQualityScoreRequestApiResult>(response);

			return result;
		}
	}
}
