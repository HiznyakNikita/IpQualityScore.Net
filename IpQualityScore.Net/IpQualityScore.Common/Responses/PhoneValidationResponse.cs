using IpQualityScore.Common.Responses.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses
{
	public class PhoneValidationResponse : IpQualityScoreResponse
	{
		[JsonProperty("valid")]
		public bool? Valid { get; set; }

		[JsonProperty("active")]
		public bool? Active { get; set; }

		[JsonProperty("formatted")]
		public string Formatted { get; set; }

		[JsonProperty("local_format")]
		public string LocalFormat { get; set; }

		[JsonProperty("fraud_score")]
		public int FraudScore { get; set; }

		[JsonProperty("recent_abuse")]
		public bool? RecentAbuse { get; set; }

		[JsonProperty("VOIP")]
		public bool? VOIP { get; set; }

		[JsonProperty("prepaid")]
		public bool? Prepaid { get; set; }

		[JsonProperty("risky")]
		public bool? Risky { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("carrier")]
		public string Carrier { get; set; }

		[JsonProperty("line_type")]
		public string LineType { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("region")]
		public string Region { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("zip_code")]
		public string ZipCode { get; set; }

		[JsonProperty("timezone")]
		public string Timezone { get; set; }
		
		[JsonProperty("dialing_code")]
		public int? DialingCode { get; set; }

		[JsonProperty("do_not_call")]
		public bool? DoNotCall { get; set; }

		[JsonProperty("leaked")]
		public bool? Leaked { get; set; }

		[JsonProperty("spammer")]
		public bool? Spammer { get; set; }

		[JsonProperty("active_status")]
		public string ActiveStatus { get; set; }

		[JsonProperty("user_activity")]
		public string UserActivity { get; set; }

		[JsonProperty("associated_email_addresses")]
		public AssociatedEmailAddressesResponse AssociatedEmailAddresses { get; set; }

		[JsonProperty("transaction_details ")]
		public TransactionDetailsResponse TransactionDetails { get; set; }
	}

	public class AssociatedEmailAddressesResponse
	{
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("emails")]
		public string[] Emails { get; set; }
	}
}
