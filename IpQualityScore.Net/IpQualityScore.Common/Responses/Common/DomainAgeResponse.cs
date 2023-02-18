using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses.Common
{
	public class DomainAgeResponse
	{
		[JsonProperty("human")]
		public string Human { get; set; }

		[JsonProperty("timestamp")]
		public int Timestamp { get; set; }

		[JsonProperty("iso")]
		public string Iso { get; set; }
	}
}
