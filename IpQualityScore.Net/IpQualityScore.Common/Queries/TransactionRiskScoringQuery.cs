using IpQualityScore.Common.Attributes;
using IpQualityScore.Common.Queries.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Queries
{
    [ApiRoute("ip")]
	public class TransactionRiskScoringQuery: IpQualityScoreQuery
	{
		[JsonProperty("strictness")]
		public int? Strictness { get; set; }

		[JsonProperty("billing_first_name")]
		public string BillingFirstName { get; set; }
		
		[JsonProperty("billing_last_name")]
		public string BillingLastName { get; set; }

		[JsonProperty("billing_company")]
		public string BillingCompany { get; set; }

		[JsonProperty("billing_country")]
		public string BillingCountry { get; set; }

		[JsonProperty("billing_address_1")] 
		public string BillingAddress1 { get; set; }

		[JsonProperty("billing_address_2")]
		public string BillingAddress2 { get; set; }

		[JsonProperty("billing_city")] 
		public string BillingCity { get; set; }

		[JsonProperty("billing_region")]
		public string BillingRegion { get; set; }

		[JsonProperty("billing_postcode")]
		public string BillingPostcode { get; set; }

		[JsonProperty("billing_email")]
		public string BillingEmail { get; set; }

		[JsonProperty("billing_phone")]
		public long? BillingPhone { get; set; }

		[JsonProperty("shipping_first_name")]
		public string ShippingFirstName { get; set; }

		[JsonProperty("shipping_last_name")]
		public string ShippingLastName { get; set; }

		[JsonProperty("shipping_company")]
		public string ShippingCompany { get; set; }

		[JsonProperty("shipping_country")]
		public string ShippingCountry { get; set; }

		[JsonProperty("shipping_address_1")]
		public string ShippingAddress1 { get; set; }

		[JsonProperty("shipping_address_2")]
		public string ShippingAddress2 { get; set; }

		[JsonProperty("shipping_city")]
		public string ShippingCity { get; set; }

		[JsonProperty("shipping_region")]
		public string ShippingRegion { get; set; }

		[JsonProperty("shipping_postcode")]
		public string ShippingPostcode { get; set; }

		[JsonProperty("shipping_email")]
		public string ShippingEmail { get; set; }

		[JsonProperty("shipping_phone")]
		public long? ShippingPhone { get; set; }

		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("password_hash")]
		public string PasswordHash { get; set; }

		[JsonProperty("credit_card_bin")]
		public long? CreditCardBin { get; set; }

		[JsonProperty("credit_card_hash")]
		public string CreditCardHash { get; set; }

		[JsonProperty("credit_card_expiration_month")]
		public int? CreditCardExpirationMonth { get; set; }

		[JsonProperty("credit_card_expiration_year")]
		public int? CreditCardExpirationYear { get; set; }

		[JsonProperty("avs_code")]
		public string AvsCode { get; set; }

		[JsonProperty("cvv_code")]
		public string CvvCode { get; set; }

		[JsonProperty("order_amount")]
		public long? OrderAmount { get; set; }

		[JsonProperty("order_quantity")]
		public long? OrderQuantity { get; set; }

		[JsonProperty("recurring")]
		public bool? Recurring { get; set; }

		[JsonProperty("recurring_times")]
		public long? RecurringTimes { get; set; }
	}
}
