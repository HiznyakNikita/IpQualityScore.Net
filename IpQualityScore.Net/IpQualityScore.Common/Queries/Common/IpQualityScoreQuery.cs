using Newtonsoft.Json;

namespace IpQualityScore.Common.Queries.Common
{
    public abstract class IpQualityScoreQuery
    {
        [JsonProperty("fast")]
        public bool? Fast { get; init; }

        [JsonProperty("timeout")]
        public int? Timeout { get; init; }

        [JsonProperty("strictness")]
        public int? Strictness { get; init; }
    }
}
