using IpQualityScore.Common.Responses.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses
{
    public class TransactionScoringResponse : IpQualityScoreResponse
	{
		[JsonProperty("proxy")]
		public bool? Proxy { get; set; }

		[JsonProperty("ISP")]
		public string ISP { get; set; }

		[JsonProperty("organization")]
		public string Organization { get; set; }

		[JsonProperty("ASN")]
		public int? ASN { get; set; }

		[JsonProperty("host")]
		public string Host { get; set; }

		[JsonProperty("country_code")]
		public string CountryCode { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("region")]
		public string Region { get; set; }

		[JsonProperty("is_crawler")]
		public bool? IsCrawler { get; set; }

		[JsonProperty("connection_type")]
		public string ConnectionType { get; set; }

		[JsonProperty("latitude")]
		public double? Latitude { get; set; }

		[JsonProperty("longitude")]
		public double? Longitude { get; set; }

		[JsonProperty("timezone")]
		public string Timezone { get; set; }

		[JsonProperty("vpn")]
		public bool? Vpn { get; set; }

		[JsonProperty("tor")]
		public bool? Tor { get; set; }

		[JsonProperty("active_vpn")]
		public bool? ActiveVpn { get; set; }

		[JsonProperty("active_tor")]
		public bool? ActiveTor { get; set; }

		[JsonProperty("transaction_details")]
		public TransactionDetailsResponse TransactionDetails { get; set; }
	}
}
