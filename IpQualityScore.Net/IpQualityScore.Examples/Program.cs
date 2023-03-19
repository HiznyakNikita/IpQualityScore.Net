using IpQualityScore.Net.Extensions;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using Microsoft.Extensions.DependencyInjection;

var apiKey = "bKaxzWxXop1bJ0bRM6KyQZ1SCpKKJqeD";
var serviceProvider = new ServiceCollection()
			.AddIpQualityScore(apiKey)
			.BuildServiceProvider();

var IpQualityScore = serviceProvider
	.GetService<IpQualityScore.Net.IpQualityScore>();

try
{
	if (IpQualityScore is not null)
	{
		//var emailValidationRequest = new EmailValidationRequest()
		//{
		//	Email = "",
		//	Fast = true,
		//	AbuseStrictness = 2,
		//	Strictness = 2,
		//	SuggestDomain = true,
		//	Timeout = 30
		//};
		//var emailValidationResult = await IpQualityScore.Email.Validate(emailValidationRequest);
		//Console.WriteLine($"Is email {emailValidationRequest.Email} valid: {emailValidationResult.Valid}");

		//var resultReportRequest = new ReportRequest() { Email = "bad_email@example.com" };
		//var resultReport = await IpQualityScore.Reports.Send(resultReportRequest);
		//Console.WriteLine($"{resultReport.Success} {resultReport.Message} {resultReport.RequestId}");

		//var transactionValidationRequest = new TransactionRiskScoringRequest()
		//{
		//	IpAddress = "",
		//	Strictness = 1,
		//	BillingEmail = "",
		//	BillingCountry = ""

		//};
		//var transactionValidationResult = await IpQualityScore.Transaction.Validate(transactionValidationRequest);
		//Console.WriteLine($"Risk factors: {string.Join(",", transactionValidationResult.TransactionDetails.RiskFactors)}");

		//var urlValidationRequest = new UrlValidationRequest()
		//{
		//	Url = "",
		//	Fast = true,
		//	Strictness = 2,
		//	Timeout = 30
		//};
		//var urlValidationResult = await IpQualityScore.Url.Validate(urlValidationRequest);
		//Console.WriteLine($"Is url {urlValidationRequest.Url} safe: {!urlValidationResult.Unsafe}");

		//var statsRequest = new StatsRequest()
		//{
		//	Country = "",
		//	EndDate = new DateOnly(2023, 2, 1),
		//	StartDate = new DateOnly(2023, 2, 20),
		//	CustomVariables = new Dictionary<string, string>()
		//	{
		//		{"UserId", "123123"},
		//		{"myvariable", "22222" }
		//	}
		//};
		//var stats = await IpQualityScore.Stats.Get(statsRequest);
		//Console.WriteLine($"Stats fraud average: {stats.FraudAverage}");

		var requestApiRequest = new IpQualityScoreRequestApiRequest()
		{
			Type = IpQualityScoreRequestType.Email,
			StartDate = new DateTime(2023, 1, 1),
			StopDate = new DateTime(2023, 2, 26)
		};
		var requestsResult = await IpQualityScore.Requests.Get<EmailValidationResult>(requestApiRequest);
		Console.WriteLine($"Requests: {string.Join(";", requestsResult.Requests.Select(r => r.RequestId))}");

//		var creditRequest = new CreditRequest()
//		{
//		};
//		var creditResult = await IpQualityScore.Credits.Get(creditRequest);
//		Console.WriteLine(@$"Credits: {creditResult.Credits};
//Usage: {creditResult.Usage}; 
//EmailUsage: {creditResult.EmailUsage}; 
//ProxyUsage: {creditResult.ProxyUsage}; 
//FingerprintUsage: {creditResult.FingerprintUsage}");
	}

}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}

Console.ReadKey();
