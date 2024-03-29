﻿using AutoMapper;
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
    internal class EmailValidator: IpQualityScoreBaseValidator, IIpQualityScoreValidator<EmailValidationResult, EmailValidationRequest>
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
				cfg.CreateMap<DomainAgeResponse, DomainAge>();
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
			ValidateRequest<EmailValidationRequestValidator, EmailValidationRequest>(request);

			var query = _mapper.Map<EmailValidationQuery>(request);
			var response = await _ipQualityScoreApiClient.Get<EmailValidationQuery, EmailValidationResponse>(query, new[] { request.Email });
			var result = _mapper.Map<EmailValidationResult>(response);

			return result;
		}
	}
}
