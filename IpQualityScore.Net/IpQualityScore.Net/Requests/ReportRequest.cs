using FluentValidation;

namespace IpQualityScore.Net.Requests
{
	public class ReportRequest
	{
		public string Email { get; init; }

		public class ReportRequestValidator : AbstractValidator<ReportRequest>
		{
			public ReportRequestValidator()
			{
				RuleFor(x => x.Email).NotEmpty();
			}
		}
	}
}
