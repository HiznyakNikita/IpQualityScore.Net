using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses
{
	public class EmailValidationResponse : IpQualityScoreResponse
	{
		[JsonProperty("valid")]
		public bool? Valid { get; set; }

		[JsonProperty("timed_out")]
		public bool? TimedOut { get; set; }

		[JsonProperty("disposable")]
		public bool? Disposable { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("deliverability")]
		public string Deliverability { get; set; }

		[JsonProperty("smtp_score")]
		public int SmtpScore { get; set; }

		[JsonProperty("overall_score")]
		public int OverallScore { get; set; }

		[JsonProperty("fraud_score")]
		public double FraudScore { get; set; }

		[JsonProperty("catch_all")]
		public bool? CatchAll { get; set; }

		[JsonProperty("generic")]
		public bool? Generic { get; set; }

		[JsonProperty("common")]
		public bool? Common { get; set; }

		[JsonProperty("dns_valid")]
		public bool? DnsValid { get; set; }

		[JsonProperty("honeypot")]
		public bool? Honeypot { get; set; }

		[JsonProperty("frequent_complainer")]
		public bool? FrequentComplainer { get; set; }

		[JsonProperty("suspect")]
		public bool? Suspect { get; set; }

		[JsonProperty("recent_abuse")]
		public bool? RecentAbuse { get; set; }

		[JsonProperty("leaked")]
		public bool? Leaked { get; set; }

		[JsonProperty("suggested_domain")]
		public string SuggestedDomain { get; set; }

		[JsonProperty("domain_velocity")]
		public string DomainVelocity { get; set; }

		[JsonProperty("user_activity")]
		public string UserActivity { get; set; }

		[JsonProperty("associated_names")]
		public AssociatedNameResponse AssociatedNames { get; set; }

		[JsonProperty("associated_phone_numbers")]
		public AssociatedPhoneNumberResponse AssociatedPhoneNumbers { get; set; }

		[JsonProperty("spam_trap_score")]
		public string SpamTrapScore { get; set; }

		[JsonProperty("first_seen")]
		public EmailValidationFirstSeenResponse FirstSeen { get; set; }

		[JsonProperty("domain_age")]
		public EmailValidationDomainAgeResponse DomainAge { get; set; }

		[JsonProperty("sanitized_email")]
		public string SanitizedEmail { get; set; }

		[JsonProperty("errors")]
		public string[] Errors { get; set; }

	}

	public class AssociatedNameResponse
	{
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("names")]
		public string[] Names { get; set; }
	}

	public class AssociatedPhoneNumberResponse
	{
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("phone_numbers")]
		public string[] PhoneNumbers { get; set; }
	}

	public class EmailValidationFirstSeenResponse
	{
		[JsonProperty("human")]
		public string Human { get; set; }
		
		[JsonProperty("timestamp")]
		public int Timestamp { get; set; }
		
		[JsonProperty("iso")]
		public string Iso { get; set; }
	}

	public class EmailValidationDomainAgeResponse
	{
		[JsonProperty("human")]
		public string Human { get; set; }

		[JsonProperty("timestamp")]
		public int Timestamp { get; set; }

		[JsonProperty("iso")]
		public string Iso { get; set; }
	}
}
