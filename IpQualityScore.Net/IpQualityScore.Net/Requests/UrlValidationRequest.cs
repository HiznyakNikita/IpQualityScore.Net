using FluentValidation;
using IpQualityScore.Net.Requests.Common;

namespace IpQualityScore.Net.Requests
{
	public class UrlValidationRequest: IpQualityScoreValidationRequest
	{
		/// <summary>
		/// Url for validation.
		/// </summary>
		public string Url { get; init; }
	}

	public class UrlValidationRequestValidator : AbstractValidator<UrlValidationRequest>
	{
		public UrlValidationRequestValidator()
		{
			RuleFor(x => x.Url).NotEmpty();
		}
	}
}
