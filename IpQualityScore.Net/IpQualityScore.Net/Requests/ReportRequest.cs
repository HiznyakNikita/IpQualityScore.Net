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

		/// <summary>
		/// Phone for report
		/// </summary>
		public string Phone { get; init; }

		/// <summary>
		/// Country for phone report
		/// </summary>
		public string Country { get; init; }

		public class ReportRequestValidator : AbstractValidator<ReportRequest>
		{
			public ReportRequestValidator()
			{
				RuleFor(m => m.Email).NotEmpty().When(m => string.IsNullOrEmpty(m.Ip) && string.IsNullOrEmpty(m.Phone) && string.IsNullOrEmpty(m.Country));
				RuleFor(m => m.Ip).NotEmpty().When(m => string.IsNullOrEmpty(m.Email) && string.IsNullOrEmpty(m.Phone) && string.IsNullOrEmpty(m.Country));
				RuleFor(m => m.Phone).NotEmpty().When(m => string.IsNullOrEmpty(m.Email) && string.IsNullOrEmpty(m.Ip));
				RuleFor(m => m.Country).NotEmpty().When(m => !string.IsNullOrEmpty(m.Phone));
			}
		}
	}
}
