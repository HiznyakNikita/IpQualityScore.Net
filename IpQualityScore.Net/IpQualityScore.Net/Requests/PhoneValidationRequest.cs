using FluentValidation;
using IpQualityScore.Net.Requests.Common;

namespace IpQualityScore.Net.Requests
{
	public class PhoneValidationRequest: IpQualityScoreValidationRequest
	{
		/// <summary>
		/// Phone address for validation.
		/// </summary>
		public string Phone { get; init; }

		/// <summary>
		/// You can optionally provide us with the default country or countries this phone number is suspected to be associated with. Our system will prefer to use a country on this list for verification or will require a country to be specified in the event the phone number is less than 10 digits.
		/// </summary>
		public string[] Country{ get; init; }
	}

	public class PhoneValidationRequestValidator : AbstractValidator<PhoneValidationRequest>
	{
		public PhoneValidationRequestValidator()
		{
			RuleFor(x => x.Phone).NotEmpty();
		}
	}
}
