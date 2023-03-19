namespace IpQualityScore.Net.Results
{
	public class CreditResult
	{
		/// <summary>
		/// Allowed credits count.
		/// </summary>
		public long Credits { get; set; }

		/// <summary>
		/// General cradit usage.
		/// </summary>
		public long Usage { get; set; }


		/// <summary>
		/// Proxy credit usage.
		/// </summary>
		public long ProxyUsage { get; set; }


		/// <summary>
		/// Email credit usage.
		/// </summary>
		public long EmailUsage { get; set; }


		/// <summary>
		/// Fingerprint credit usage.
		/// </summary>
		public long FingerprintUsage { get; set; }
	}
}
