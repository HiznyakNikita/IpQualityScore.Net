using FluentValidation;
using IpQualityScore.Net.Requests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpQualityScore.Net.Requests
{
	public class UrlValidationRequest: IpQualityScoreValidationRequest
	{
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
