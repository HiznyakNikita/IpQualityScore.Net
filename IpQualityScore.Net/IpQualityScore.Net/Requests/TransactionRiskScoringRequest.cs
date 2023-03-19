using FluentValidation;

namespace IpQualityScore.Net.Requests
{
	public class TransactionRiskScoringRequest
	{
		/// <summary>
		/// IP address to score.
		/// </summary>
		public string IpAddress { get; set; }

		/// <summary>
		/// Sets how strictly spam traps and honeypots are detected by our system, depending on how comfortable you are with identifying emails suspected of being a spam trap. 0 is the lowest level which will only return spam traps with high confidence. Strictness levels above 0 will return increasingly more strict results, with level 2 providing the greatest detection rates.
		/// </summary>
		public int Strictness { get; set; }

		/// <summary>
		/// The customer's billing first name.
		/// </summary>
		public string BillingFirstName { get; set; }

		/// <summary>
		/// The customer's billing last name.
		/// </summary>
		public string BillingLastName { get; set; }

		/// <summary>
		/// The customer's billing company.
		/// </summary>
		public string BillingCompany { get; set; }

		/// <summary>
		/// The customer's billing country name or billing country ISO-Alpha2. (EG: United States or US)
		/// </summary>
		public string BillingCountry { get; set; }

		/// <summary>
		/// The customer's billing street address part 1.
		/// </summary>
		public string BillingAddress1 { get; set; }

		/// <summary>
		/// The customer's billing street address part 2.
		/// </summary>
		public string BillingAddress2 { get; set; }

		/// <summary>
		/// The customer's billing city.
		/// </summary>
		public string BillingCity { get; set; }

		/// <summary>
		/// The customer's billing region or state.
		/// </summary>
		public string BillingRegion { get; set; }

		/// <summary>
		/// The customer's billing postcode or zipcode.
		/// </summary>
		public string BillingPostcode { get; set; }

		/// <summary>
		/// The customer's billing email address.
		/// </summary>
		public string BillingEmail { get; set; }

		/// <summary>
		/// The customer's billing 11 to 14 digit phone number. (If less than 10 digits provided, the country code will be guessed by our AI.)
		/// </summary>
		public long BillingPhone { get; set; }

		/// <summary>
		/// The customer's shipping first name.
		/// </summary>
		public string ShippingFirstName { get; set; }

		/// <summary>
		/// The customer's shipping last name.
		/// </summary>
		public string ShippingLastName { get; set; }

		/// <summary>
		/// The customer's shipping company.
		/// </summary>
		public string ShippingCompany { get; set; }

		/// <summary>
		/// The customer's shipping country name or shipping country ISO-Alpha2. (EG: United States or US)
		/// </summary>
		public string ShippingCountry { get; set; }

		/// <summary>
		/// The customer's shipping street address part 1.
		/// </summary>
		public string ShippingAddress1 { get; set; }

		/// <summary>
		/// The customer's shipping street address part 2.
		/// </summary>
		public string ShippingAddress2 { get; set; }

		/// <summary>
		/// The customer's shipping city.
		/// </summary>
		public string ShippingCity { get; set; }

		/// <summary>
		/// The customer's shipping region or state.
		/// </summary>
		public string ShippingRegion { get; set; }

		/// <summary>
		/// The customer's shipping postcode or zipcode.
		/// </summary>
		public string ShippingPostcode { get; set; }

		/// <summary>
		/// The customer's shipping email address.
		/// </summary>
		public string ShippingEmail { get; set; }

		/// <summary>
		/// The customer's shipping 11 to 14 digit phone number. (If less than 10 digits provided, the country code will be guessed by our AI.)
		/// </summary>
		public long ShippingPhone { get; set; }

		/// <summary>
		/// The customer's username.
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// For security reasons and following industry best practices, a SHA256 hash of the user's password for better user analysis.
		/// </summary>
		public string PasswordHash { get; set; }

		/// <summary>
		/// First six digits of the credit or debit card, referred to ask the Bank Identification Number.
		/// </summary>
		public long CreditCardBin { get; set; }

		/// <summary>
		/// For security reasons and following industry best practices, a SHA256 hash of the credit card number is accepted to check against blacklisted cards.
		/// </summary>
		public string CreditCardHash { get; set; }

		/// <summary>
		/// Two letter format of the credit card's expiration month. For example, May would be "05".
		/// </summary>
		public int CreditCardExpirationMonth { get; set; }

		/// <summary>
		/// Two letter format of the credit card's expiration year. For example, 2022 would be "22".
		/// </summary>
		public int CreditCardExpirationYear { get; set; }

		/// <summary>
		/// One letter Address Verification Service (AVS) response code provided by the credit card processor or bank. A full list of acceptable response codes can be viewed here. If your system cannot retrieve the exact response code, values of "pass" or "fail" can be used.
		/// </summary>
		public string AvsCode { get; set; }

		/// <summary>
		/// One letter Card Verification Value (CVV2) response code provided by the credit card processor or bank. A full list of acceptable response codes can be viewed here. If your system cannot retrieve the exact response code, values of "pass" or "fail" can be used.
		/// </summary>
		public string CvvCode { get; set; }

		/// <summary>
		/// Total balance of the entire order without currency symbols.
		/// </summary>
		public long OrderAmount { get; set; }

		/// <summary>
		/// Quantity of items for this order.
		/// </summary>
		public long OrderQuantity { get; set; }

		/// <summary>
		/// Is this a recurring order that automatically rebills?
		/// </summary>
		public bool Recurring { get; set; }

		/// <summary>
		/// If this is a recurring order, then how many times has this recurring order rebilled? For example, if this is the third time the user is being billed, please enter this value as "3". If this is the initial recurring order, please leave the value as blank or enter "1".
		/// </summary>
		public long RecurringTimes { get; set; }
	}

	public class TransactionRiskScoringRequestValidator : AbstractValidator<TransactionRiskScoringRequest>
	{
		public TransactionRiskScoringRequestValidator()
		{
			RuleFor(x => x.IpAddress).NotEmpty();
		}
	}
}
