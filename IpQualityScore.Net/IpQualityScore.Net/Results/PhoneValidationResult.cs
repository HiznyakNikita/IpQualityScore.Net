using IpQualityScore.Net.Results.Common;

namespace IpQualityScore.Net.Results
{
	public class PhoneValidationResult : IpQualityScoreRequestResult
	{
		/// <summary>
		/// Is the phone number properly formatted and considered valid based on assigned phone numbers available to carriers in that country?
		/// </summary>
		public bool? Valid { get; set; }

		/// <summary>
		/// Is this phone number a live usable phone number that is currently active?
		/// </summary>
		public bool? Active { get; set; }

		/// <summary>
		/// The phone number formatted in the international dialing code. N/A if not formattable.
		/// </summary>
		public string Formatted { get; set; }

		/// <summary>
		/// The phone number formatted in the country's local routing rules with area code. N/A if not formattable.	
		/// </summary>
		public string LocalFormat { get; set; }

		/// <summary>
		/// The IPQS risk score which estimates how likely a phone number is to be fraudulent. Scores 85+ are risky while Fraud Scores 90+ are high risk.
		/// </summary>
		public int FraudScore { get; set; }

		/// <summary>
		/// Has this phone number been associated with recent or ongoing fraud?
		/// </summary>
		public bool? RecentAbuse { get; set; }

		/// <summary>
		/// Is this phone number a Voice Over Internet Protocol (VOIP) or digital phone number?
		/// </summary>
		public bool? VOIP { get; set; }

		/// <summary>
		/// Is this phone number associated with a prepaid service plan?
		/// </summary>
		public bool? Prepaid { get; set; }

		/// <summary>
		/// Is this phone number associated with fraudulent activity, scams, robo calls, fake accounts, or other unfriendly behavior?
		/// </summary>
		public bool? Risky { get; set; }

		/// <summary>
		/// The owner name of the phone number such as the first or last name or business name assigned to the phone number. Multiple names will be returned in comma separated format. Value is "N/A" if unknown.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The carrier (service provider) this phone number has been assigned to or "N/A" if unknown.
		/// </summary>
		public string Carrier { get; set; }

		/// <summary>
		/// The type of line this phone number is associated with (Toll Free, Mobile, Landline, Satellite, VOIP, Premium Rate, Pager, etc...) or "N/A" if unknown.
		/// </summary>
		public string LineType { get; set; }

		/// <summary>
		/// The two character country code for this phone number.
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// Region (state) of the phone number if available or "N/A" if unknown.
		/// </summary>
		public string Region { get; set; }

		/// <summary>
		/// City of the phone number if available or "N/A" if unknown.
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// Zip or Postal code of the phone number if available or "N/A" if unknown.
		/// </summary>
		public string ZipCode { get; set; }

		/// <summary>
		/// Timezone of the phone number if available or "N/A" if unknown.
		/// </summary>
		public string Timezone { get; set; }

		/// <summary>
		/// The 1 to 4 digit dialing code for this phone number or null if unknown.
		/// </summary>
		public int? DialingCode { get; set; }

		/// <summary>
		/// Indicates if the phone number is listed on any Do Not Call (DNC) lists. Only supported in US and CA. This data may not be 100% up to date with the latest DNC blacklists. Contact your account mangaer to enable better DNC data and TCPA litigator removal.
		/// </summary>
		public bool? DoNotCall { get; set; }

		/// <summary>
		/// Has this phone number recently been exposed in an online database breach or act of compromise.
		/// </summary>
		public bool? Leaked { get; set; }

		/// <summary>
		/// Indicates if the phone number has recently been reported for spam or harassing calls/texts.
		/// </summary>
		public bool? Spammer { get; set; }

		/// <summary>
		/// Additional details on the status of the subscriber connection when enhanced active line checks are enabled. Contact your account manager to enable this add-on feature. These values can be "Active Line", "Disconnected Line", "Phone Turned Off", "Inconclusive Status", or "N/A" if unknown.
		/// </summary>
		public string ActiveStatus { get; set; }

		/// <summary>
		/// Frequency at which this phone number makes legitimate purchases, account registrations, and engages in legitimate user behavior online. Values can be "high", "medium", "low", or "none". Values of "high" or "medium" are strong signals of healthy usage. New phone numbers without a history of legitimate behavior will have a value as "none". This field is restricted to higher plan tiers.
		/// </summary>
		public string UserActivity { get; set; }

		/// <summary>
		/// Displays email addresses linked to the phone number, if available in our data sources. Match rates vary by country and line type. This field is restricted to upgraded plans. Object value contains, "status", and "emails" as an array.
		/// </summary>
		public AssociatedEmailAddresses AssociatedEmailAddresses { get; set; }

		/// <summary>
		/// Additional scoring variables for risk analysis are available when transaction scoring data is passed through the API request. These variables are also useful for scoring user data such as physical addresses, phone numbers, usernames, and transaction details. The data points below are populated when at least 1 transaction data parameter is present in the initial API request. The following transaction variables are "null" when the necessary transaction parameters are not passed with the initial API request. For instance, not passing the "billing_email" will return "valid_billing_email" as null
		/// </summary>
		public TransactionDetails TransactionDetails { get; set; }
	}

	public class AssociatedEmailAddresses
	{
		public string Status { get; set; }

		public string[] Emails { get; set; }
	}
}
