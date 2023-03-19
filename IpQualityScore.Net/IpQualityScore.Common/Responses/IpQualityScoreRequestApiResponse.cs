using IpQualityScore.Common.Responses.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses
{
	public class IpQualityScoreRequestApiResponse<TType> : IpQualityScoreResponse
		where TType: IpQualityScoreResponse, new()
	{
		[JsonProperty("current_page")]
		public int CurrentPage { get; init; }

		[JsonProperty("total_pages")]
		public int TotalPages { get; init; }

		[JsonProperty("request_count")]
		public int RequestCount { get; init; }

		[JsonProperty("max_records_per_page")]
		public int MaxRecordsPerPage { get; init; }

		[JsonProperty("total_requests")]
		public int TotaRequests { get; init; }

		[JsonProperty("requests")]
		public IReadOnlyCollection<TType> Requests { get; init; }
	}
}
