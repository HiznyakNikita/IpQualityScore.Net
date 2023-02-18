using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses.Common
{
    public class IpQualityScoreResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }
    }
}
