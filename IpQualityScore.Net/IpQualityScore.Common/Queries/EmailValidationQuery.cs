using IpQualityScore.Common.Attributes;
using IpQualityScore.Common.Queries.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Queries
{
    [ApiRoute("email")]
	public class EmailValidationQuery : IpQualityScoreQuery
	{

		[JsonProperty("suggest_domain")]
		public bool? SuggestDomain { get; init; }


		[JsonProperty("abuse_strictness")]
		public int? AbuseStrictness { get; init; }
	}
}
