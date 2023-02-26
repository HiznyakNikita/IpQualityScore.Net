using IpQualityScore.Common;
using IpQualityScore.Net.Providers;
using IpQualityScore.Net.Providers.Contract;
using IpQualityScore.Net.Reports;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using IpQualityScore.Net.Validators;
using IpQualityScore.Net.Validators.Common;

namespace IpQualityScore.Net
{
    public class IpQualityScore
	{
		public IIpQualityScoreValidator<EmailValidationResult, EmailValidationRequest> Email { get; init; }
		public IIpQualityScoreValidator<TransactionRiskScoringResult, TransactionRiskScoringRequest> Transaction { get; init; }
		public IReportsSender Reports { get; set; }
		public IIpQualityScoreValidator<UrlValidationResult, UrlValidationRequest> Url { get; init; }

		public IStatsProvider Stats { get; set; }
		public IIpQualityScoreRequestsProvider Requests { get; set; }
		public ICreditProvider Credits { get; set; }

		public IpQualityScore(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{

			Email = new EmailValidator(ipQualityScoreApiClient);
			Url = new UrlValidator(ipQualityScoreApiClient);
			Reports = new ReportsSender(ipQualityScoreApiClient);
			Transaction = new TransactionValidator(ipQualityScoreApiClient);
			Stats = new StatsProvider(ipQualityScoreApiClient);
			Requests = new IpQualityScoreRequestsProvider(ipQualityScoreApiClient);
			Credits = new CreditProvider(ipQualityScoreApiClient);
		}
	}
}
