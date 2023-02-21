using IpQualityScore.Common.Responses.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses
{
	public class StatsResponse : IpQualityScoreResponse
	{
		[JsonProperty("fraud_average")]
		public string FraudAverage { get; set; }
	}
}
