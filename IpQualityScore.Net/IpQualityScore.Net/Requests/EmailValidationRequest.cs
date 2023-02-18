using FluentValidation;
using IpQualityScore.Net.Requests.Common;

namespace IpQualityScore.Net.Requests
{
	public class EmailValidationRequest: IpQualityScoreValidationRequest
	{
		public string Email { get; init; }
		public bool? SuggestDomain { get; init; }
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
