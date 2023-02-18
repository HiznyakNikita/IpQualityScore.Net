using IpQualityScore.Common.Attributes;
using IpQualityScore.Common.Queries.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Queries
{
    [ApiRoute("report")]
	public class ReportQuery : IpQualityScoreQuery
	{
		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("ip")]
		public string Ip { get; set; }
	}
}
