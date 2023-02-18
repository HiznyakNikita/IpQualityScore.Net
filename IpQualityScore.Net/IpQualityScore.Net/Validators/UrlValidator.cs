using AutoMapper;
using IpQualityScore.Common.Queries;
using IpQualityScore.Common.Responses;
using IpQualityScore.Common;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using IpQualityScore.Common.Responses.Common;
using IpQualityScore.Net.Results.Common;
using IpQualityScore.Net.Validators.Common;

namespace IpQualityScore.Net.Validators
{
	internal class UrlValidator : IpQualityScoreBaseValidator, IIpQualityScoreValidator<UrlValidationResult, UrlValidationRequest>
	{
		private readonly IMapper _mapper;
		private readonly IIpQualityScoreApiClient _ipQualityScoreApiClient;

		public UrlValidator(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<UrlValidationResponse, UrlValidationResult>();
				cfg.CreateMap<DomainAgeResponse, DomainAge>();
				cfg.CreateMap<UrlValidationRequest, UrlValidationQuery>();
			});
			_mapper = mapperConfig.CreateMapper();

			_ipQualityScoreApiClient = ipQualityScoreApiClient;
		}

		public async Task<UrlValidationResult> Validate(UrlValidationRequest request)
		{
			if (request == null)
				throw new ArgumentException(nameof(request));
			ValidateRequest<UrlValidationRequestValidator, UrlValidationRequest>(request);

			var query = _mapper.Map<UrlValidationQuery>(request);
			var response = await _ipQualityScoreApiClient.Get<UrlValidationQuery, UrlValidationResponse>(query, new[] { request.Url });
			var result = _mapper.Map<UrlValidationResult>(response);

			return result;
		}
	}
}
