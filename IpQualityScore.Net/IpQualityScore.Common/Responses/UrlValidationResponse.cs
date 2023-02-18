using IpQualityScore.Common.Responses.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses
{
	public class UrlValidationResponse: IpQualityScoreResponse
	{
		[JsonProperty("unsafe")]
		public bool Unsafe { get; set; }

		[JsonProperty("domain")]
		public string Domain { get; set; }

		[JsonProperty("ip_address")]
		public string IpAddress { get; set; }

		[JsonProperty("country_code")]
		public string CountryCode { get; set; }

		[JsonProperty("server")]
		public string Server { get; set; }

		[JsonProperty("content_type")]
		public string ContentType { get; set; }

		[JsonProperty("risk_score")]
		public int RiskScore { get; set; }

		[JsonProperty("status_code")]
		public int StatusCode { get; set; }

		[JsonProperty("page_size")]
		public int PageSize { get; set; }

		[JsonProperty("domain_rank")]
		public int DomainRank { get; set; }

		[JsonProperty("dns_valid")]
		public bool DnsValid { get; set; }

		[JsonProperty("suspicious")]
		public bool Suspicious { get; set; }

		[JsonProperty("phishing")]
		public bool Phishing { get; set; }

		[JsonProperty("malware")]
		public bool Malware { get; set; }

		[JsonProperty("parking")]
		public bool Parking { get; set; }

		[JsonProperty("spamming")]
		public bool Spamming { get; set; }

		[JsonProperty("adult")]
		public bool Adult { get; set; }

		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("domain_age")]
		public DomainAgeResponse DomainAge { get; set; }
	}
}
