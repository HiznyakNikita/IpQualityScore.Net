using FluentValidation;

namespace IpQualityScore.Net.Requests
{
	public class EmailValidationRequest
	{
		public string Email { get; init; }
		public bool? Fast { get; init; }
		public int? Timeout { get; init; }
		public bool? SuggestDomain { get; init; }
		public int? Strictness { get; init; }
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
