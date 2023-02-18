using IpQualityScore.Net.Results.Common;

namespace IpQualityScore.Net.Results
{
	public class EmailValidationResult
	{
		public bool? Valid { get; set; }
		public bool? TimedOut { get; set; }
		public bool? Disposable { get; set; }
		public string FirstName { get; set; }
		public string Deliverability { get; set; }
		public int SmtpScore { get; set; }
		public int OverallScore { get; set; }
		public double FraudScore { get; set; }
		public bool? CatchAll { get; set; }
		public bool? Generic { get; set; }
		public bool? Common { get; set; }
		public bool? DnsValid { get; set; }
		public bool? Honeypot { get; set; }
		public bool? FrequentComplainer { get; set; }
		public bool? Suspect { get; set; }
		public bool? RecentAbuse { get; set; }
		public bool? Leaked { get; set; }
		public string SuggestedDomain { get; set; }
		public string DomainVelocity { get; set; }
		public string UserActivity { get; set; }
		public AssociatedName AssociatedNames { get; set; }
		public AssociatedPhoneNumber AssociatedPhoneNumbers { get; set; }
		public string SpamTrapScore { get; set; }
		public EmailFirstSeen FirstSeen { get; set; }
		public DomainAge DomainAge { get; set; }
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
		public string Human { get; set; }
		
		public int Timestamp { get; set; }
		
		public string Iso { get; set; }
	}
}
