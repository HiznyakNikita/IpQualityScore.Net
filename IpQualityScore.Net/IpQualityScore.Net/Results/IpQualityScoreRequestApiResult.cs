namespace IpQualityScore.Net.Results
{
	public class IpQualityScoreRequestApiResult
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
		public IReadOnlyCollection<IpQualityScoreRequest> Requests { get; init; }
	}

	public class IpQualityScoreRequest
	{
		public string RequestId { get; init; }

		public string ASN { get; init; }

		public string ISP { get; init; }

		public string CountryCode { get; init; }

		public string Region { get; init; }

		public string City { get; init; }

		public string Organization { get; init; }

		public double Latitude { get; init; }

		public double longitude { get; init; }

		public bool IsCrawler { get; init; }

		public string Timezone { get; init; }

		public bool Mobile { get; init; }

		public string Host { get; init; }

		public bool Proxy { get; init; }

		public bool Vpn { get; init; }

		public bool Tor { get; init; }

		public bool RecentAbuse { get; init; }

		public bool BotStatus { get; init; }

		public bool Success { get; init; }

		public string Message { get; init; }

		public int FraudScore { get; init; }

		public string[] TransactionDetails { get; init; }
	}
}
