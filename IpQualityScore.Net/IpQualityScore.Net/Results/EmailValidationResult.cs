using IpQualityScore.Net.Results.Common;

namespace IpQualityScore.Net.Results
{
	public class EmailValidationResult: IpQualityScoreRequestResult
	{
		/// <summary>
		/// Does this email address appear valid?
		/// </summary>
		public bool? Valid { get; set; }
		
		/// <summary>
		/// Did the connection to the mail service provider timeout during the verification? If so, we recommend increasing the "timeout" variable above the default 7 second value. Lookups that timeout with a "valid" result as false are most likely false and should be not be trusted.
		/// </summary>
		public bool? TimedOut { get; set; }
		
		/// <summary>
		/// Is this email suspected of belonging to a temporary or disposable mail service? Usually associated with fraudsters and scammers.
		/// </summary>
		public bool? Disposable { get; set; }

		/// <summary>
		/// Suspected first name based on email. Returns "CORPORATE" if the email is suspected of being a generic company email. Returns "UNKNOWN" if the first name was not determinable.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// How likely is this email to be delivered to the user and land in their mailbox. Values can be "high", "medium", or "low".
		/// </summary>
		public string Deliverability { get; set; }
		
		/// <summary>
		/// Validity score of email server's SMTP setup. Range: "-1" - "3". Scores above "-1" can be associated with a valid email.
		/// -1 = invalid email address
		/// 0 = mail server exists, but is rejecting all mail
		/// 1 = mail server exists, but is showing a temporary error
		/// 2 = mail server exists, but accepts all email
		/// 3 = mail server exists and has verified the email address
		/// </summary>
		public int SmtpScore { get; set; }
		
		/// <summary>
		/// Overall email validity score. Range: "0" - "4". Scores above "1" can be associated with a valid email.
		/// 0 = invalid email address
		/// 1 = dns valid, unreachable mail server
		/// 2 = dns valid, temporary mail rejection error
		/// 3 = dns valid, accepts all mail
		/// 4 = dns valid, verified email exists
		/// </summary>
		public int OverallScore { get; set; }

		/// <summary>
		/// The overall Fraud Score of the user based on the email's reputation and recent behavior across the IPQS threat network. Fraud Scores >= 75 are suspicious, but not necessarily fraudulent.
		/// </summary>
		public double FraudScore { get; set; }
		
		public bool? CatchAll { get; set; }

		/// <summary>
		/// Is this email suspected as being a catch all or shared email for a domain? ("admin@", "webmaster@", "newsletter@", "sales@", "contact@", etc.)
		/// </summary>
		public bool? Generic { get; set; }

		/// <summary>
		/// 	Is this email from a common email provider? ("gmail.com", "yahoo.com", "hotmail.com", etc.)
		/// </summary>
		public bool? Common { get; set; }

		/// <summary>
		/// Does the email's hostname have valid DNS entries? Partial indication of a valid email.
		/// </summary>
		public bool? DnsValid { get; set; }

		/// <summary>
		/// Is this email believed to be a "honeypot" or "SPAM trap"? Bulk mail sent to these emails increases your risk of being blacklisted by large ISPs & ending up in the spam folder.
		/// </summary>
		public bool? Honeypot { get; set; }

		/// <summary>
		/// Indicates if this email frequently unsubscribes from marketing lists or reports email as SPAM.
		/// </summary>
		public bool? FrequentComplainer { get; set; }
		
		public bool? Suspect { get; set; }

		/// <summary>
		/// 	This value will indicate if there has been any recently verified abuse across our network for this email address. Abuse could be a confirmed chargeback, fake signup, compromised device, fake app install, or similar malicious behavior within the past few days.
		/// </summary>
		public bool? RecentAbuse { get; set; }
		
		public bool? Leaked { get; set; }

		/// <summary>
		/// Default value is "N/A". Indicates if this email's domain should in fact be corrected to a popular mail service. This field is useful for catching user typos. For example, an email address with "gmai.com", would display a suggested domain of "gmail.com". This feature supports all major mail service providers.
		/// </summary>
		public string SuggestedDomain { get; set; }

		/// <summary>
		/// Indicates the level of legitimate users interacting with the email address domain. Values can be "high", "medium", "low", or "none". Domains like "IBM.com", "Microsoft.com", "Gmail.com", etc. will have "high" scores as this value represents popular domains. New domains or domains that are not frequently visited by legitimate users will have a value as "none". This field is restricted to upgraded plans.
		/// </summary>
		public string DomainVelocity { get; set; }

		/// <summary>
		/// Frequency at which this email address makes legitimate purchases, account registrations, and engages in legitimate user behavior online. Values can be "high", "medium", "low", or "none". Values of "high" or "medium" are strong signals of healthy usage. New email addresses without a history of legitimate behavior will have a value as "none". This field is restricted to higher plan tiers.
		/// </summary>
		public string UserActivity { get; set; }

		/// <summary>
		/// Displays first and last names linked to the email address, if available in our data sources. Match rates vary by country. This field is restricted to upgraded plans. Object value contains, "status", and "names" as an array.
		/// </summary>
		public AssociatedName AssociatedNames { get; set; }

		/// <summary>
		/// 	Displays phone numbers linked to the email address, if available in our data sources. Match rates vary by country. This field is restricted to upgraded plans. Object value contains, "status", and "phone_numbers" as an array.
		/// </summary>
		public AssociatedPhoneNumber AssociatedPhoneNumbers { get; set; }

		/// <summary>
		/// Confidence level of the email address being an active SPAM trap. Values can be "high", "medium", "low", or "none". We recommend scrubbing emails with "high" or "medium" statuses. Avoid "low" emails whenever possible for any promotional mailings.
		/// </summary>
		public string SpamTrapScore { get; set; }

		/// <summary>
		/// Email address age info
		/// </summary>
		public EmailFirstSeen FirstSeen { get; set; }

		/// <summary>
		/// Domain address age info
		/// </summary>
		public DomainAge DomainAge { get; set; }

		/// <summary>
		/// Sanitized email address with all aliases and masking removed, such as multiple periods for Gmail.com.
		/// </summary>
		public string SanitizedEmail { get; set; }
	}
	public class AssociatedName
	{		
		public string Status { get; set; }
		public string[] Names { get; set; }
	}

	public class AssociatedPhoneNumber
	{		
		public string Status { get; set; }
		public string[] PhoneNumbers { get; set; }
	}

	public class EmailFirstSeen
	{
		/// <summary>
		/// A human description of the email address age, using an estimation of the email creation date when IPQS first discovered this email address. (Ex: 3 months ago)
		/// </summary>
		public string Human { get; set; }

		/// <summary>
		/// The unix time since epoch when this email was first analyzed by IPQS.
		/// </summary>
		public int Timestamp { get; set; }

		/// <summary>
		/// The time this email was first analyzed by IPQS in ISO8601
		/// </summary>
		public string Iso { get; set; }
	}
}
