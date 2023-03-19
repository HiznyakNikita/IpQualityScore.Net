namespace IpQualityScore.Net.Results.Common
{
	public class DomainAge
	{
		/// <summary>
		/// A human description of when this domain was registered. (Ex: 3 months ago)
		/// </summary>
		public string Human { get; set; }

		/// <summary>
		/// The unix time since epoch when this domain was first registered. 
		/// </summary>
		public int Timestamp { get; set; }

		/// <summary>
		/// The time this domain was registered in ISO8601 format
		/// </summary>
		public string Iso { get; set; }
	}
}
