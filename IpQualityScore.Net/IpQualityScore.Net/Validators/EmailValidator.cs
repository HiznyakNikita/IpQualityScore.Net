using AutoMapper;
using IpQualityScore.Net.Exceptions;
using IpQualityScore.Net.Results;
using Newtonsoft.Json;

namespace IpQualityScore.Net.Validators
{
	internal class EmailValidator: IIpQualityScoreValidator<EmailValidationResult, string>
	{
		private const string _path = "email";
		private readonly string _url;
		private readonly IMapper _mapper;

		public EmailValidator(string apiKey, string baseUrl): base()
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<EmailValidationResponse, EmailValidationResult>();
				cfg.CreateMap<AssociatedNameResponse, AssociatedName>();
				cfg.CreateMap<AssociatedPhoneNumberResponse, AssociatedPhoneNumber>();
				cfg.CreateMap<EmailValidationDomainAgeResponse, EmailDomainAge>();
				cfg.CreateMap<EmailValidationFirstSeenResponse, EmailFirstSeen>();
			});
			_mapper = mapperConfig.CreateMapper();

			_url = $"{baseUrl}{_path}/{apiKey}";
		}

		public async Task<EmailValidationResult> Validate(string email)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"{_url}/{email}")
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<EmailValidationResponse>(body);
				if (result is null)
					throw new Exception($"Error occurred while validation: {email}");
				if (!result.Success.GetValueOrDefault())
				{
					throw new IpQualityScoreException(result.RequestId, result.Message);
				}

				return _mapper.Map<EmailValidationResult>(result);
			}
		}
	}
}
