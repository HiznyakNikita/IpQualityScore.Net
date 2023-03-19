namespace IpQualityScore.Net.Requests
{
	public class StatsRequest
	{
		/// <summary>
		/// The 2 character country code of the IP lookups to average or 'all'. (OPTIONAL).
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// The start date for generating the average. (OPTIONAL).
		/// </summary>
		public DateOnly StartDate { get; set; }

		/// <summary>
		/// The end date for generating the average. (OPTIONAL).
		/// </summary>
		public DateOnly EndDate { get; set; }

		/// <summary>
		/// Any custom variable associated with your account (userID, transactionID, etc.).
		/// </summary>
		public IReadOnlyDictionary<string,string> CustomVariables { get; set; }
	}
}
