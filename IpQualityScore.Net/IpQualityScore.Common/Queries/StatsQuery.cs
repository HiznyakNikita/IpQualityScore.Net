using IpQualityScore.Common.Queries.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Queries
{
	public class StatsQuery: IpQualityScoreQuery
	{
		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("start_date")]
		public string StartDate { get; set; }

		[JsonProperty("end_date")]
		public string EndDate { get; set; }

		public IReadOnlyDictionary<string, string> CustomVariables { get; set; }
	}
}
