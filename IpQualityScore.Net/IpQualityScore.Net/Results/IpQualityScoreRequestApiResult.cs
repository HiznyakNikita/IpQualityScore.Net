using IpQualityScore.Net.Results.Common;

namespace IpQualityScore.Net.Results
{
	public class IpQualityScoreRequestApiResult<TType>
		where TType: IpQualityScoreRequestResult, new()
	{
		/// <summary>
		/// Which page of results was returned by this query.
		/// </summary>
		public int CurrentPage { get; init; }

		/// <summary>
		/// Total number of results pages this query produced.
		/// </summary>
		public int TotalPages { get; init; }

		/// <summary>
		/// How many results are on this page.
		/// </summary>
		public int RequestCount { get; init; }

		/// <summary>
		/// How many results this response should contain.
		/// </summary>
		public int MaxRecordsPerPage { get; init; }

		/// <summary>
		/// How many results exist in total for this query.
		/// </summary>
		public int TotalRequests { get; init; }

		/// <summary>
		/// Array of result objects.
		/// </summary>
		public IReadOnlyCollection<TType> Requests { get; init; }
	}
}
