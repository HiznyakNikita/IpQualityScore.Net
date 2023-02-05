using AutoMapper;
using IpQualityScore.Common.Extensions;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using Newtonsoft.Json;
using IpQualityScore.Common;
using IpQualityScore.Common.Responses;
using IpQualityScore.Common.Queries;

namespace IpQualityScore.Net.Validators
{
	internal class EmailValidator: IIpQualityScoreValidator<EmailValidationResult, EmailValidationRequest>
	{
		private readonly IMapper _mapper;
		private readonly IIpQualityScoreApiClient _ipQualityScoreApiClient;

		public EmailValidator(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<EmailValidationResponse, EmailValidationResult>();
				cfg.CreateMap<AssociatedNameResponse, AssociatedName>();
				cfg.CreateMap<AssociatedPhoneNumberResponse, AssociatedPhoneNumber>();
				cfg.CreateMap<EmailValidationDomainAgeResponse, EmailDomainAge>();
				cfg.CreateMap<EmailValidationFirstSeenResponse, EmailFirstSeen>();
				cfg.CreateMap<EmailValidationRequest, EmailValidationQuery>();
			});
			_mapper = mapperConfig.CreateMapper();

			_ipQualityScoreApiClient = ipQualityScoreApiClient;
		}

		public async Task<EmailValidationResult> Validate(EmailValidationRequest request)
		{
			if (request == null)
				throw new ArgumentException(nameof(request));

			var query = _mapper.Map<EmailValidationQuery>(request);
			var response = await _ipQualityScoreApiClient.Get<EmailValidationQuery, EmailValidationResponse>(query, new[] { request.Email });
			var result = _mapper.Map<EmailValidationResult>(response);

			return result;
		}
	}
}
