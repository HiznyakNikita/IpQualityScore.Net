using IpQualityScore.Net.Extensions;
using IpQualityScore.Net.Requests;
using Microsoft.Extensions.DependencyInjection;

var apiKey = "";
var serviceProvider = new ServiceCollection()
			.AddIpQualityScore(apiKey)
			.BuildServiceProvider();


var request = new EmailValidationRequest()
{
	Email = "",
	Fast = true,
	AbuseStrictness = 2,
	Strictness = 2,
	SuggestDomain = true,
	Timeout = 30
};

var IpQualityScore = serviceProvider
	.GetService< IpQualityScore.Net.IpQualityScore>();

try
{
	var resultValidation = await IpQualityScore.Email.Validate(request);
	Console.WriteLine($"Is email valid: {resultValidation.Valid}");

	var resultReport = await IpQualityScore.Reports.Send(new ReportRequest() { Email = "bad_email@example.com" });
	Console.WriteLine($"{resultReport.Success} {resultReport.Message} {resultReport.RequestId}");

}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}

Console.ReadKey();
