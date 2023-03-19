using Newtonsoft.Json;

namespace IpQualityScore.Common.Responses
{
	public class TransactionDetailsResponse
	{
		[JsonProperty("valid_billing_address")]
		public bool? ValidBillingAddress { get; set; }

		[JsonProperty("valid_shipping_address")]
		public bool? ValidShippingAddress { get; set; }

		[JsonProperty("valid_billing_email")]
		public bool? ValidBillingEmail { get; set; }

		[JsonProperty("valid_shipping_email")]
		public bool? ValidShippingEmail { get; set; }

		[JsonProperty("risky_billing_phone")]
		public bool? RiskyBillingPhone { get; set; }

		[JsonProperty("risky_shipping_phone")]
		public bool? RiskyShippingPhone { get; set; }

		[JsonProperty("billing_phone_carrier")]
		public string BillingPhoneCarrier { get; set; }

		[JsonProperty("shipping_phone_carrier")]
		public string ShippingPhoneCarrier { get; set; }

		[JsonProperty("billing_phone_line_type")]
		public string BillingPhoneLineType { get; set; }

		[JsonProperty("shipping_phone_line_type")]
		public string ShippingPhoneLineType { get; set; }

		[JsonProperty("billing_phone_country")]
		public string BillingPhoneCountry { get; set; }

		[JsonProperty("billing_phone_country_code")]
		public string BillingPhoneCountryCode { get; set; }

		[JsonProperty("shipping_phone_country")]
		public string ShippingPhoneCountry { get; set; }

		[JsonProperty("shipping_phone_country_code")]
		public string ShippingPhoneCountryCode { get; set; }

		[JsonProperty("fraudulent_behavior")]
		public bool? FraudulentBehavior { get; set; }

		[JsonProperty("bin_country")]
		public string BinCountry { get; set; }

		[JsonProperty("risk_score")]
		public int? RiskScore { get; set; }

		[JsonProperty("risk_factors")]
		public IReadOnlyCollection<string> RiskFactors { get; set; }

		[JsonProperty("is_prepaid_card")]
		public bool? IsPrepaidCard { get; set; }

		[JsonProperty("risky_username")]
		public bool? RiskyUsername { get; set; }

		[JsonProperty("valid_billing_phone")]
		public bool? ValidBillingPhone { get; set; }

		[JsonProperty("valid_shipping_phone")]
		public bool? ValidShippingPhone { get; set; }

		[JsonProperty("leaked_billing_email")]
		public bool? LeakedBillingEmail { get; set; }

		[JsonProperty("leaked_shipping_email")]
		public bool? LeakedShippingEmail { get; set; }

		[JsonProperty("leaked_user_data")]
		public bool? LeakedUserData { get; set; }

		[JsonProperty("user_activity")]
		public string UserActivity { get; set; }

		[JsonProperty("phone_name_identity_match")]
		public string PhoneNameIdentityMatch { get; set; }

		[JsonProperty("phone_email_identity_match")]
		public string PhoneEmailIdentityMatch { get; set; }

		[JsonProperty("phone_address_identity_match")]
		public string PhoneAddressIdentityMatch { get; set; }

		[JsonProperty("email_name_identity_match")]
		public string EmailNameIdentityMatch { get; set; }

		[JsonProperty("name_address_identity_match")]
		public string NameAddressIdentityMatch { get; set; }

		[JsonProperty("address_email_identity_match")]
		public string AddressEmailIdentityMatch { get; set; }
	}
}
