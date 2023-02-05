using Newtonsoft.Json;

namespace IpQualityScore.Net.Queries
{
	internal class ReportQuery
	{
		[JsonProperty("email")]
		public string Email { get; set; }
	}
}
