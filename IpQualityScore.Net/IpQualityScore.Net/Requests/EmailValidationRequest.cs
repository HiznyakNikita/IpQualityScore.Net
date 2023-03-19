using FluentValidation;
using IpQualityScore.Net.Requests.Common;

namespace IpQualityScore.Net.Requests
{
	public class EmailValidationRequest: IpQualityScoreValidationRequest
	{
		/// <summary>
		/// Email address for validation.
		/// </summary>
		public string Email { get; init; }

		/// <summary>
		/// Force analyze if the email address's domain has a typo and should be corrected to a popular mail service. By default, this test is currently only performed when the email is invalid or if the "recent abuse" status is true.
		/// </summary>
		public bool? SuggestDomain { get; init; }

		/// <summary>
		/// Set the strictness level for machine learning pattern recognition of abusive email addresses with the "recent_abuse" data point. Default level of 0 provides good coverage, however if you are filtering account applications and facing advanced fraudsters then we recommend increasing this value to level 1 or 2.
		/// </summary>
		public int? AbuseStrictness { get; init; }
	}

	public class EmailValidationRequestValidator : AbstractValidator<EmailValidationRequest>
	{
		public EmailValidationRequestValidator()
		{
			RuleFor(x => x.Email).NotEmpty();
		}
	}
}
