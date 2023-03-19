namespace IpQualityScore.Net.Results
{
	public class TransactionRiskScoringResult
	{
		/// <summary>
		/// Is this IP address suspected to be a proxy? (SOCKS, Elite, Anonymous, VPN, Tor, etc.)
		/// </summary>
		public bool? Proxy { get; set; }

		/// <summary>
		/// ISP if one is known. Otherwise "N/A".
		/// </summary>
		public string ISP { get; set; }

		/// <summary>
		/// Organization if one is known. Can be parent company or sub company of the listed ISP. Otherwise "N/A".
		/// </summary>
		public string Organization { get; set; }

		/// <summary>
		/// Autonomous System Number if one is known. Null if nonexistent.
		/// </summary>
		public int? ASN { get; set; }

		/// <summary>
		/// Hostname of the IP address if one is available.
		/// </summary>
		public string Host { get; set; }

		/// <summary>
		/// Two character country code of IP address or "N/A" if unknown.
		/// </summary>
		public string CountryCode { get; set; }

		/// <summary>
		/// City of IP address if available or "N/A" if unknown.
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// Region (state) of IP address if available or "N/A" if unknown.
		/// </summary>
		public string Region { get; set; }

		/// <summary>
		/// Is this IP associated with being a confirmed crawler from a mainstream search engine such as Googlebot, Bingbot, Yandex, etc. based on hostname or IP address verification.
		/// </summary>
		public bool? IsCrawler { get; set; }

		/// <summary>
		/// Classification of the IP address connection type as "Residential", "Corporate", "Education", "Mobile", or "Data Center".
		/// </summary>
		public string ConnectionType { get; set; }

		/// <summary>
		/// Latitude of IP address if available or "N/A" if unknown.
		/// </summary>
		public double? Latitude { get; set; }

		/// <summary>
		/// Longitude of IP address if available or "N/A" if unknown.
		/// </summary>
		public double? Longitude { get; set; }

		/// <summary>
		/// Timezone of IP address if available or "N/A" if unknown.
		/// </summary>
		public string Timezone { get; set; }

		/// <summary>
		/// Is this IP suspected of being a VPN connection? This can include data center ranges which can become active VPNs at any time. The "proxy" status will always be true when this value is true.
		/// </summary>
		public bool? Vpn { get; set; }

		/// <summary>
		/// Is this IP suspected of being a TOR connection? This can include previously active TOR nodes and exits which can become active TOR exits at any time. The "proxy" status will always be true when this value is true.
		/// </summary>
		public bool? Tor { get; set; }

		/// <summary>
		/// Premium Account Feature
		/// Identifies active VPN connections used by popular VPN services and private VPN servers.
		/// </summary>
		public bool? ActiveVpn { get; set; }

		/// <summary>
		/// Premium Account Feature
		/// Identifies active TOR exits on the TOR network.
		/// </summary>
		public bool? ActiveTor { get; set; }

		/// <summary>
		/// Additional details of transaction.
		/// </summary>
		public TransactionDetails TransactionDetails { get; set; }
	}

	public class TransactionDetails
	{
		/// <summary>
		/// Physical address validation and reputation analysis.
		/// </summary>
		public bool? ValidBillingAddress { get; set; }

		/// <summary>
		/// Physical address validation and reputation analysis.
		/// </summary>
		public bool? ValidShippingAddress { get; set; }

		/// <summary>
		/// Light abusive check and reputation analysis for the email address. It is recommended to use our dedicated Email Validation API for deeper analysis.
		/// </summary>
		public bool? ValidBillingEmail { get; set; }

		/// <summary>
		/// Light abusive check and reputation analysis for the email address. It is recommended to use our dedicated Email Validation API for deeper analysis.
		/// </summary>
		public bool? ValidShippingEmail { get; set; }

		/// <summary>
		/// Reputation analysis for abusive activity associated with the phone number.
		/// </summary>
		public bool? RiskyBillingPhone { get; set; }

		/// <summary>
		/// Reputation analysis for abusive activity associated with the phone number.
		/// </summary>
		public bool? RiskyShippingPhone { get; set; }

		/// <summary>
		/// Phone number provider company such as "AT&T" or "Bell Canada".
		/// </summary>
		public string BillingPhoneCarrier { get; set; }

		/// <summary>
		/// Phone number provider company such as "AT&T" or "Bell Canada".
		/// </summary>
		public string ShippingPhoneCarrier { get; set; }

		/// <summary>
		/// Landline, Wireless, Toll Free, VOIP, Satellite, Premium Rate, Pager, Internet Service Provider or Unknown.
		/// </summary>
		public string BillingPhoneLineType { get; set; }

		/// <summary>
		/// Landline, Wireless, Toll Free, VOIP, Satellite, Premium Rate, Pager, Internet Service Provider or Unknown.
		/// </summary>
		public string ShippingPhoneLineType { get; set; }

		/// <summary>
		/// 2-letter country code associated with the phone number.
		/// </summary>
		public string BillingPhoneCountry { get; set; }

		/// <summary>
		/// Country dialing code associated with the phone number.
		/// </summary>
		public string BillingPhoneCountryCode { get; set; }

		/// <summary>
		/// 2-letter country code associated with the phone number.
		/// </summary>
		public string ShippingPhoneCountry { get; set; }

		/// <summary>
		/// Country dialing code associated with the phone number.
		/// </summary>
		public string ShippingPhoneCountryCode { get; set; }

		/// <summary>
		/// Indicates high risk behavior patterns and a high chance of fraud.
		/// </summary>
		public bool? FraudulentBehavior { get; set; }

		/// <summary>
		/// Country associated with the credit card BIN.
		/// </summary>
		public string BinCountry { get; set; }

		/// <summary>
		/// Confidence that this user or transaction is exhibiting malicious behavior. Scores are 0 - 100, with 75+ as suspicious and 90+ as high risk. This value uses different calculations with less weight on the IP reputation compared to the overall "Fraud Score".
		/// </summary>
		public int? RiskScore { get; set; }

		/// <summary>
		/// Explanation for elevated Risk Scores to better understand why the payment or user was associated with fraudulent behavior and considered a high risk.
		/// </summary>
		public IReadOnlyCollection<string> RiskFactors { get; set; }

		/// <summary>
		/// Status of the credit card as prepaid.
		/// </summary>
		public bool? IsPrepaidCard { get; set; }

		/// <summary>
		/// Username frequently associated with fraudulent behavior.
		/// </summary>
		public bool? RiskyUsername { get; set; }

		/// <summary>
		/// Valid & active phone number with the phone carrier (not disconnected).
		/// </summary>
		public bool? ValidBillingPhone { get; set; }

		/// <summary>
		/// Valid & active phone number with the phone carrier (not disconnected).
		/// </summary>
		public bool? ValidShippingPhone { get; set; }

		/// <summary>
		/// Indicates if the email address has recently been exposed or compromised in a database breach.
		/// </summary>
		public bool? LeakedBillingEmail { get; set; }

		/// <summary>
		/// Indicates if the email address has recently been exposed or compromised in a database breach.
		/// </summary>
		public bool? LeakedShippingEmail { get; set; }

		/// <summary>
		/// Indicates if the user's data (including phone & address) have recently been exposed or compromised in a database breach.
		/// </summary>
		public bool? LeakedUserData { get; set; }

		/// <summary>
		/// Frequency at which this user makes legitimate purchases, account registrations, and engages in legitimate customer behavior online. Values can be "high", "medium", "low", or "none". Values of "high" or "medium" are strong signals of healthy usage. New user data without a history of legitimate behavior will have a value as "none". This field is restricted to higher plan tiers.
		/// </summary>
		public string UserActivity { get; set; }

		/// <summary>
		/// Enterprise Account Feature
		/// Indicates a reverse identity match between the billing phone number and first/last name. Values: "Unknown" - no checks processed, "Match" - positive identity match, "Mismatch" - data matches another user, "No Match" - could not pair identity data.
		/// </summary>
		public string PhoneNameIdentityMatch { get; set; }

		/// <summary>
		/// Enterprise Account Feature
		/// Indicates a reverse identity match between the billing phone number and email address. Values: "Unknown" - no checks processed, "Match" - positive identity match, "Mismatch" - data matches another user, "No Match" - could not pair identity data.
		/// </summary>
		public string PhoneEmailIdentityMatch { get; set; }

		/// <summary>
		/// Enterprise Account Feature
		/// Indicates a reverse identity match between the billing phone number and physical address. Values: "Unknown" - no checks processed, "Match" - positive identity match, "Mismatch" - data matches another user, "No Match" - could not pair identity data.
		/// </summary>
		public string PhoneAddressIdentityMatch { get; set; }

		/// <summary>
		/// Enterprise Account Feature
		/// Indicates a reverse identity match between the billing email address and first/last name. Values: "Unknown" - no checks processed, "Match" - positive identity match, "Mismatch" - data matches another user, "No Match" - could not pair identity data.
		/// </summary>
		public string EmailNameIdentityMatch { get; set; }

		/// <summary>
		/// Enterprise Account Feature
		/// Indicates a reverse identity match between the billing first/last name and physical address. Values: "Unknown" - no checks processed, "Match" - positive identity match, "Mismatch" - data matches another user, "No Match" - could not pair identity data.
		/// </summary>
		public string NameAddressIdentityMatch { get; set; }

		/// <summary>
		/// Enterprise Account Feature
		/// Indicates a reverse identity match between the billing physical address and email address. Values: "Unknown" - no checks processed, "Match" - positive identity match, "Mismatch" - data matches another user, "No Match" - could not pair identity data.
		/// </summary>
		public string AddressEmailIdentityMatch { get; set; }
	}
}
