using Newtonsoft.Json;

namespace IpQualityScore.Net.Responses
{
	internal class IpQualityScoreResponse
	{
		[JsonProperty("request_id")]
		public string RequestId { get; set; }

		[JsonProperty("success")]
		public bool? Success { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }
	}
}
