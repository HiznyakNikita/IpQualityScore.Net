using IpQualityScore.Common.Responses.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses
{
	public class CreditResponse : IpQualityScoreResponse
	{
		[JsonProperty("credits")]
		public long Credits { get; set; }

		[JsonProperty("usage")]
		public long Usage { get; set; }

		[JsonProperty("proxy_usage")]
		public long ProxyUsage { get; set; }

		[JsonProperty("email_usage")]
		public long EmailUsage { get; set; }

		[JsonProperty("fingerprint_usage")]
		public long FingerprintUsage { get; set; }

	}
}
