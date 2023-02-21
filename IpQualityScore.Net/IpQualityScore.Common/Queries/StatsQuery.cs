using IpQualityScore.Common.Attributes;
using IpQualityScore.Common.Queries.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IpQualityScore.Common.Queries
{
	[ApiRoute("proxy/average")]
	public class StatsQuery: IpQualityScoreQuery
	{
		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("start_date")]
		public string StartDate { get; set; }

		[JsonProperty("end_date")]
		public string EndDate { get; set; }

		[JsonExtensionData]
		public IDictionary<string, JToken> CustomVariables { get; set; }
	}
}
