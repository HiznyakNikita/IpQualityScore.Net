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
	/// <summary>
	/// Instance of IpQualityScore API
	/// </summary>
    public class IpQualityScore
	{
		/// <summary>
		/// Email Validation API
		/// <see href="https://www.ipqualityscore.com/documentation/email-validation/overview">See more</see>
		/// </summary>
		public IIpQualityScoreValidator<EmailValidationResult, EmailValidationRequest> Email { get; init; }

		/// <summary>
		/// Payment & Transaction Fraud Prevention API
		/// <see href="https://www.ipqualityscore.com/documentation/proxy-detection/transaction-scoring">See more</see>
		/// </summary>
		public IIpQualityScoreValidator<TransactionRiskScoringResult, TransactionRiskScoringRequest> Transaction { get; init; }

		/// <summary>
		/// Fraud Reporting API
		/// <see href="https://www.ipqualityscore.com/documentation/fraud-reporting/overview">See more</see>
		/// </summary>
		public IReportsSender Reports { get; set; }

		/// <summary>
		/// Malicious URL Scanner API
		/// <see href="https://www.ipqualityscore.com/documentation/malicious-url-scanner-api/overview">See more</see> 
		/// </summary>
		public IIpQualityScoreValidator<UrlValidationResult, UrlValidationRequest> Url { get; init; }

		/// <summary>
		/// Stats & Averages API
		/// <see href="https://www.ipqualityscore.com/documentation/proxy-detection/averages">See more</see> 
		/// </summary>
		public IStatsProvider Stats { get; set; }

		/// <summary>
		/// Request List API
		/// <see href="https://www.ipqualityscore.com/documentation/request-list/overview">See more</see> 
		/// </summary>
		public IIpQualityScoreRequestListProvider Requests { get; set; }

		/// <summary>
		/// Credit Usage API
		/// <see href="https://www.ipqualityscore.com/documentation/usage/overview">See more</see> 
		/// </summary>
		public ICreditProvider Credits { get; set; }

		public IpQualityScore(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{

			Email = new EmailValidator(ipQualityScoreApiClient);
			Url = new UrlValidator(ipQualityScoreApiClient);
			Reports = new ReportsSender(ipQualityScoreApiClient);
			Transaction = new TransactionValidator(ipQualityScoreApiClient);
			Stats = new StatsProvider(ipQualityScoreApiClient);
			Requests = new IpQualityScoreRequestListProvider(ipQualityScoreApiClient);
			Credits = new CreditProvider(ipQualityScoreApiClient);
		}
	}
}
