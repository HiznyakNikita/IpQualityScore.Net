using FluentValidation;

namespace IpQualityScore.Net.Requests
{
	public class ReportRequest
	{
		/// <summary>
		/// Email for report
		/// </summary>
		public string Email { get; init; }

		/// <summary>
		/// IP for report
		/// </summary>
		public string Ip { get; init; }

		public class ReportRequestValidator : AbstractValidator<ReportRequest>
		{
			public ReportRequestValidator()
			{
				RuleFor(m => m.Email).NotEmpty().When(m => string.IsNullOrEmpty(m.Ip));
				RuleFor(m => m.Ip).NotEmpty().When(m => string.IsNullOrEmpty(m.Email));
			}
		}
	}
}
