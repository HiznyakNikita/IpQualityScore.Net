using IpQualityScore.Common.Attributes;
using IpQualityScore.Common.Queries.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Queries
{
    [ApiRoute("phone")]
	public class PhoneValidationQuery : IpQualityScoreQuery
	{
		[JsonProperty("country")]
		public string[] Country { get; init; }
	}
}
