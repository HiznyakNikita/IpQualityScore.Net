using IpQualityScore.Common.Attributes;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Queries
{
	[ApiRoute("report")]
	public class ReportQuery : IpQualityScoreQuery
	{
		[JsonProperty("email")]
		public string Email { get; set; }
	}
}
