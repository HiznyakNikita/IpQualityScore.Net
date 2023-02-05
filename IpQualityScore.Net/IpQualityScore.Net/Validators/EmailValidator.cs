using AutoMapper;
using IpQualityScore.Net.Exceptions;
using IpQualityScore.Net.Extensions;
using IpQualityScore.Net.Queries;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Responses;
using IpQualityScore.Net.Results;
using Newtonsoft.Json;

namespace IpQualityScore.Net.Validators
{
	internal class EmailValidator: IIpQualityScoreValidator<EmailValidationResult, EmailValidationRequest>
	{
		private const string _path = "email";
		private readonly string _url;
		private readonly IMapper _mapper;

		public EmailValidator(string apiKey, string baseUrl)
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

			_url = $"{baseUrl}{_path}/{apiKey}";
		}

		public async Task<EmailValidationResult> Validate(EmailValidationRequest request)
		{
			if (request == null)
				throw new ArgumentException(nameof(request));

			var query = _mapper.Map<EmailValidationQuery>(request);
			var client = new HttpClient();
			var apiRequest = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"{_url}/{request.Email}?{await query.ToUrlEncodedString()}")
			};
			using (var response = await client.SendAsync(apiRequest))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<EmailValidationResponse>(body);
				if (result is null)
					throw new Exception($"Error occurred while validation: {request.Email}");
				if (!result.Success.GetValueOrDefault())
				{
					throw new IpQualityScoreException(result.RequestId, result.Message);
				}

				return _mapper.Map<EmailValidationResult>(result);
			}
		}
	}
}
