using AutoMapper;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using IpQualityScore.Common;
using IpQualityScore.Common.Responses;
using IpQualityScore.Common.Queries;
using IpQualityScore.Net.Results.Common;
using IpQualityScore.Common.Responses.Common;
using IpQualityScore.Net.Validators.Common;

namespace IpQualityScore.Net.Validators
{
    internal class PhoneValidator: IpQualityScoreBaseValidator, IIpQualityScoreValidator<PhoneValidationResult, PhoneValidationRequest>
	{
		private readonly IMapper _mapper;
		private readonly IIpQualityScoreApiClient _ipQualityScoreApiClient;

		public PhoneValidator(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<PhoneValidationResponse, PhoneValidationResult>();
				cfg.CreateMap<AssociatedEmailAddressesResponse, AssociatedEmailAddresses>();
				cfg.CreateMap<TransactionDetailsResponse, TransactionDetails>();
				cfg.CreateMap<PhoneValidationRequest, PhoneValidationQuery>();
			});
			_mapper = mapperConfig.CreateMapper();

			_ipQualityScoreApiClient = ipQualityScoreApiClient;
		}

		public async Task<PhoneValidationResult> Validate(PhoneValidationRequest request)
		{
			if (request == null)
				throw new ArgumentException(nameof(request));
			ValidateRequest<PhoneValidationRequestValidator, PhoneValidationRequest>(request);

			var query = _mapper.Map<PhoneValidationQuery>(request);
			var response = await _ipQualityScoreApiClient.Get<PhoneValidationQuery, PhoneValidationResponse>(query, new[] { request.Phone });
			var result = _mapper.Map<PhoneValidationResult>(response);

			return result;
		}
	}
}
