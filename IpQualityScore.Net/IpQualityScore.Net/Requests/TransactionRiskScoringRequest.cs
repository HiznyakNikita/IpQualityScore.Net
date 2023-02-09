using System.Diagnostics;

namespace IpQualityScore.Net.Requests
{
	public class TransactionRiskScoringRequest
	{
		public string IpAddress { get; set; }

		public int Strictness { get; set; }
		public string BillingFirstName { get; set; }

		public string BillingLastName { get; set; }

		public string BillingCompany { get; set; }

		public string BillingCountry { get; set; }

		public string BillingAddress1 { get; set; }

		public string BillingAddress2 { get; set; }

		public string BillingCity { get; set; }

		public string BillingRegion { get; set; }

		public string BillingPostcode { get; set; }

		public string BillingEmail { get; set; }

		public long BillingPhone { get; set; }

		public string ShippingFirstName { get; set; }

		public string ShippingLastName { get; set; }

		public string ShippingCompany { get; set; }

		public string ShippingCountry { get; set; }

		public string ShippingAddress1 { get; set; }

		public string ShippingAddress2 { get; set; }

		public string ShippingCity { get; set; }

		public string ShippingRegion { get; set; }

		public string ShippingPostcode { get; set; }

		public string ShippingEmail { get; set; }

		public long ShippingPhone { get; set; }

		public string Username { get; set; }

		public string PasswordHash { get; set; }

		public long CreditCardBin { get; set; }

		public string CreditCardHash { get; set; }

		public int CreditCardExpirationMonth { get; set; }

		public int CreditCardExpirationYear { get; set; }

		public string AvsCode { get; set; }

		public string CvvCode { get; set; }

		public long OrderAmount { get; set; }

		public long OrderQuantity { get; set; }

		public bool Recurring { get; set; }

		public long RecurringTimes { get; set; }
	}
}
