using IpQualityScore.Net.Results;
using IpQualityScore.Net.Validators;

namespace IpQualityScore.Net
{
	public class IpQualityScore
	{
		private readonly string _apiKey;
		private readonly string _baseUrl;

		public IIpQualityScoreValidator<EmailValidationResult, string> Email { get; init; }

		public IpQualityScore(string apiKey)
		{
			_apiKey = apiKey;
			_baseUrl = $"https://ipqualityscore.com/api/json/";

			Email = new EmailValidator(_apiKey, _baseUrl);
		}
	}
}
