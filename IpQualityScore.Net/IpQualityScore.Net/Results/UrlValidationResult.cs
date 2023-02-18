using IpQualityScore.Net.Results.Common;

namespace IpQualityScore.Net.Results
{
	public class UrlValidationResult
	{
		public bool Unsafe { get; set; }

		public string Domain { get; set; }

		public string IpAddress { get; set; }

		public string CountryCode { get; set; }

		public string Server { get; set; }

		public string ContentType { get; set; }

		public int RiskScore { get; set; }

		public int StatusCode { get; set; }

		public int PageSize { get; set; }

		public int DomainRank { get; set; }

		public bool DnsValid { get; set; }

		public bool Suspicious { get; set; }

		public bool Phishing { get; set; }

		public bool Malware { get; set; }

		public bool Parking { get; set; }

		public bool Spamming { get; set; }

		public bool Adult { get; set; }

		public string Category { get; set; }

		public DomainAge DomainAge { get; set; }
	}
}
