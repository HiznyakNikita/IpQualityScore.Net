using IpQualityScore.Common.Extensions;
using IpQualityScore.Common.Queries;
using IpQualityScore.Net.Extensions;
using IpQualityScore.Net.Requests;
using Microsoft.Extensions.DependencyInjection;

var apiKey = "";
var serviceProvider = new ServiceCollection()
			.AddIpQualityScore(apiKey)
			.BuildServiceProvider();

var IpQualityScore = serviceProvider
	.GetService< IpQualityScore.Net.IpQualityScore>();

try
{
	var statsQuery = new StatsQuery()
	{
		Country = "UA",
		EndDate = DateTime.Now.AddHours(2).ToString("yyyy-MM-dd"),
		StartDate = DateTime.Now.ToString("yyyy-MM-dd"),
		CustomVariables = new Dictionary<string, string>()
		{
			{"UserId", "123123"},
			{"myvariable", "22222" }
		}
	};
	var url = statsQuery.ToUrlEncodedString();
	if (IpQualityScore is not null)
	{
		var emailValidationRequest = new EmailValidationRequest()
		{
			Email = "",
			Fast = true,
			AbuseStrictness = 2,
			Strictness = 2,
			SuggestDomain = true,
			Timeout = 30
		};
		var emailValidationResult = await IpQualityScore.Email.Validate(emailValidationRequest);
		Console.WriteLine($"Is email {emailValidationRequest.Email} valid: {emailValidationResult.Valid}");

		var resultReport = await IpQualityScore.Reports.Send(new ReportRequest() { Email = "bad_email@example.com" });
		Console.WriteLine($"{resultReport.Success} {resultReport.Message} {resultReport.RequestId}");

		var transactionValidationRequest = new TransactionRiskScoringRequest()
		{
			IpAddress = "",
			Strictness = 1,
			BillingEmail = "",
			BillingCountry = ""

		};
		var transactionValidationResult = await IpQualityScore.Transaction.Validate(transactionValidationRequest);
		Console.WriteLine($"Risk factors: {string.Join(",", transactionValidationResult.TransactionDetails.RiskFactors)}");

		var urlValidationRequest = new UrlValidationRequest()
		{
			Url = "",
			Fast = true,
			Strictness = 2,
			Timeout = 30
		};
		var urlValidationResult = await IpQualityScore.Url.Validate(urlValidationRequest);
		Console.WriteLine($"Is url {urlValidationRequest.Url} safe: {!urlValidationResult.Unsafe}");
	}

}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}

Console.ReadKey();
