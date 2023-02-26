using IpQualityScore.Common.Attributes;
using IpQualityScore.Common.Queries.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IpQualityScore.Common.Queries
{
	[ApiRoute("requests")]
	public class IpQualityScoreRequestApiQuery: IpQualityScoreQuery
	{
		[JsonProperty("type")]
		public string Type { get; init; }

		[JsonProperty("page")]
		public int? Page { get; init; }

		[JsonProperty("limit")]
		public int? Limit { get; init; }

		[JsonProperty("start_date")]
		public string StartDate { get; init; }

		[JsonProperty("stop_date")]
		public string StopDate { get; init; }

		[JsonProperty("tracker_id")]
		public int? TrackerId { get; init; }

		[JsonProperty("device_id")]
		public string DeviceId { get; init; }

		[JsonProperty("min_fraud_score")]
		public int? MinFraudScore { get; init; }

		[JsonProperty("max_fraud_score")]
		public int? MaxFraudScore { get; init; }

		[JsonProperty("ip_address\t")]
		public string IpAddress { get; init; }

		[JsonExtensionData]
		public IDictionary<string, JToken> CustomVariables { get; init; }
	}
}
