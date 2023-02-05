using IpQualityScore.Net.Requests;

var apiKey = "";
var request = new EmailValidationRequest()
{
	Email = "",
	Fast = true,
	AbuseStrictness = 2,
	Strictness = 2,
	SuggestDomain = true,
	Timeout = 30
};

var IpQualityScore = new IpQualityScore.Net.IpQualityScore(apiKey);

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
