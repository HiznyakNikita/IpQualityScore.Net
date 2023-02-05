using IpQualityScore.Common.Attributes;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Queries
{
	[ApiRoute("email")]
	public class EmailValidationQuery : IpQualityScoreQuery
	{

		[JsonProperty("fast")]
		public bool? Fast { get; init; }

		[JsonProperty("timeout")]
		public int? Timeout { get; init; }

		[JsonProperty("suggest_domain")]
		public bool? SuggestDomain { get; init; }

		[JsonProperty("strictness")]

		public int? Strictness { get; init; }

		[JsonProperty("abuse_strictness")]
		public int? AbuseStrictness { get; init; }
	}
}
