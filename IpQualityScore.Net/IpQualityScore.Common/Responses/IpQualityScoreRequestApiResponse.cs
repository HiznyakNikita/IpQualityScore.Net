using IpQualityScore.Common.Responses.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses
{
	public class IpQualityScoreRequestApiResponse : IpQualityScoreResponse
	{
		[JsonProperty("current_page")]
		public int CurrentPage { get; init; }

		[JsonProperty("total_pages")]
		public int TotalPages { get; init; }

		[JsonProperty("request_count")]
		public int RequestCount { get; init; }

		[JsonProperty("max_records_per_page")]
		public int MaxRecordsPerPage { get; init; }

		[JsonProperty("total_requests")]
		public int TotaRequests { get; init; }

		[JsonProperty("requests")]
		public IReadOnlyCollection<IpQualityScoreApiRequest> Requests { get; init; }
	}

	public class IpQualityScoreApiRequest
	{
		[JsonProperty("request_id")]
		public string RequestId { get; init; }

		[JsonProperty("ASN")]
		public string ASN { get; init; }

		[JsonProperty("ISP")]
		public string ISP { get; init; }

		[JsonProperty("country_code")]
		public string CountryCode { get; init; }

		[JsonProperty("region")]
		public string Region { get; init; }

		[JsonProperty("city")]
		public string City { get; init; }

		[JsonProperty("organization")]
		public string Organization { get; init; }

		[JsonProperty("latitude")]
		public double Latitude { get; init; }

		[JsonProperty("longitude")]
		public double longitude { get; init; }

		[JsonProperty("is_crawler")]
		public bool IsCrawler { get; init; }

		[JsonProperty("timezone")]
		public string Timezone { get; init; }

		[JsonProperty("mobile")]
		public bool Mobile { get; init; }

		[JsonProperty("host")]
		public string Host { get; init; }

		[JsonProperty("proxy")]
		public bool Proxy { get; init; }

		[JsonProperty("vpn")]
		public bool Vpn { get; init; }

		[JsonProperty("tor")]
		public bool Tor { get; init; }

		[JsonProperty("recent_abuse")]
		public bool RecentAbuse { get; init; }

		[JsonProperty("bot_status")]
		public bool BotStatus { get; init; }

		[JsonProperty("success")]
		public bool Success { get; init; }

		[JsonProperty("message")]
		public string Message { get; init; }

		[JsonProperty("fraud_score")]
		public int FraudScore { get; init; }

		[JsonProperty("transaction_details")]
		public string[] TransactionDetails { get; init; }
	}
}
