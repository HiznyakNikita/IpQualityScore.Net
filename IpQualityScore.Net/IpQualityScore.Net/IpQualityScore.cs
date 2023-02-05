using IpQualityScore.Common;
using IpQualityScore.Net.Reports;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using IpQualityScore.Net.Validators;

namespace IpQualityScore.Net
{
	public class IpQualityScore
	{
		public IIpQualityScoreValidator<EmailValidationResult, EmailValidationRequest> Email { get; init; }
		public IReportsSender Reports { get; set; }

		public IpQualityScore(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{

			Email = new EmailValidator(ipQualityScoreApiClient);
			Reports = new ReportsSender(ipQualityScoreApiClient);
		}
	}
}
