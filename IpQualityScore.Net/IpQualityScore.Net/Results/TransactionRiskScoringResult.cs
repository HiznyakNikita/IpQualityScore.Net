using IpQualityScore.Common.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpQualityScore.Net.Results
{
	public class TransactionRiskScoringResult
	{
		public bool? Proxy { get; set; }

		public string ISP { get; set; }

		public string Organization { get; set; }

		public int? ASN { get; set; }

		public string Host { get; set; }

		public string CountryCode { get; set; }

		public string City { get; set; }

		public string Region { get; set; }

		public bool? IsCrawler { get; set; }

		public string ConnectionType { get; set; }

		public double? Latitude { get; set; }

		public double? Longitude { get; set; }

		public string Timezone { get; set; }

		public bool? Vpn { get; set; }

		public bool? Tor { get; set; }

		public bool? ActiveVpn { get; set; }

		public bool? ActiveTor { get; set; }

		public TransactionDetails TransactionDetails { get; set; }
	}

	public class TransactionDetails
	{
		public bool? ValidBillingAddress { get; set; }

		public bool? ValidShippingAddress { get; set; }

		public bool? ValidBillingEmail { get; set; }

		public bool? ValidShippingEmail { get; set; }

		public bool? RiskyBillingPhone { get; set; }

		public bool? RiskyShippingPhone { get; set; }

		public string BillingPhoneCarrier { get; set; }

		public string ShippingPhoneCarrier { get; set; }

		public string BillingPhoneLineType { get; set; }

		public string ShippingPhoneLineType { get; set; }

		public string BillingPhoneCountry { get; set; }

		public string BillingPhoneCountryCode { get; set; }

		public string ShippingPhoneCountry { get; set; }

		public string ShippingPhoneCountryCode { get; set; }

		public bool? FraudulentBehavior { get; set; }

		public string BinCountry { get; set; }

		public int? RiskScore { get; set; }

		public IReadOnlyCollection<string> RiskFactors { get; set; }

		public bool? IsPrepaidCard { get; set; }

		public bool? RiskyUsername { get; set; }

		public bool? ValidBillingPhone { get; set; }

		public bool? ValidShippingPhone { get; set; }

		public bool? LeakedBillingEmail { get; set; }

		public bool? LeakedShippingEmail { get; set; }

		public bool? LeakedUserData { get; set; }

		public string UserActivity { get; set; }

		public string PhoneNameIdentityMatch { get; set; }

		public string PhoneEmailIdentityMatch { get; set; }

		public string PhoneAddressIdentityMatch { get; set; }

		public string EmailNameIdentityMatch { get; set; }

		public string NameAddressIdentityMatch { get; set; }

		public string AddressEmailIdentityMatch { get; set; }
	}
}
