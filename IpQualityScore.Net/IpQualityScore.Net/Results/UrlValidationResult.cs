using IpQualityScore.Net.Results.Common;

namespace IpQualityScore.Net.Results
{
	public class UrlValidationResult: IpQualityScoreRequestResult
	{
		/// <summary>
		/// Is this domain suspected of being unsafe due to phishing, malware, spamming, or abusive behavior? View the confidence level by analyzing the "risk_score".
		/// </summary>
		public bool Unsafe { get; set; }

		/// <summary>
		/// Domain name of the final destination URL of the scanned link, after following all redirects.
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// The IP address corresponding to the server of the domain name.
		/// </summary>
		public string IpAddress { get; set; }

		/// <summary>
		/// The country corresponding to the server's IP address.
		/// </summary>
		public string CountryCode { get; set; }

		/// <summary>
		/// The 2-letter ISO code corresponding to the content's language on this URL/domain.
		/// </summary>
		public string LanguageCode { get; set; }

		/// <summary>
		/// The server banner of the domain's IP address. For example: "nginx/1.16.0". Value will be "N/A" if unavailable.
		/// </summary>
		public string Server { get; set; }

		/// <summary>
		/// MIME type of URL's content. For example "text/html; charset=UTF-8". Value will be "N/A" if unavailable.
		/// </summary>
		public string ContentType { get; set; }

		/// <summary>
		/// The IPQS risk score which estimates the confidence level for malicious URL detection. Risk Scores 85+ are high risk, while Risk Scores = 100 are confirmed as accurate.
		/// </summary>
		public int RiskScore { get; set; }

		/// <summary>
		/// HTTP Status Code of the URL's response. This value should be "200" for a valid website. Value is "0" if URL is unreachable.
		/// </summary>
		public int StatusCode { get; set; }

		/// <summary>
		/// Total number of bytes to download the URL's content. Value is "0" if URL is unreachable.
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// Estimated popularity rank of website globally. Value is "0" if the domain is unranked or has low traffic.
		/// </summary>
		public int DomainRank { get; set; }

		/// <summary>
		/// The domain of the URL has valid DNS records.
		/// </summary>
		public bool DnsValid { get; set; }

		/// <summary>
		/// Is this URL suspected of being malicious or used for phishing or abuse? Use in conjunction with the "risk_score" as a confidence level.
		/// </summary>
		public bool Suspicious { get; set; }

		/// <summary>
		/// Is this URL associated with malicious phishing behavior?
		/// </summary>
		public bool Phishing { get; set; }

		/// <summary>
		/// Is this URL associated with malware or viruses?
		/// </summary>
		public bool Malware { get; set; }

		/// <summary>
		/// Is the domain of this URL currently parked with a for sale notice?
		/// </summary>
		public bool Parking { get; set; }

		/// <summary>
		/// Is the domain of this URL associated with email SPAM or abusive email addresses?
		/// </summary>
		public bool Spamming { get; set; }

		/// <summary>
		/// Is this URL or domain hosting dating or adult content?
		/// </summary>
		public bool Adult { get; set; }

		/// <summary>
		/// Website classification and category related to the content and industry of the site. Over 70 categories are available including "Video Streaming", "Trackers", "Gaming", "Privacy", "Advertising", "Hacking", "Malicious", "Phishing", etc. The value will be "N/A" if unknown.
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// Info about when this domain was first registered.
		/// </summary>
		public DomainAge DomainAge { get; set; }
	}
}
