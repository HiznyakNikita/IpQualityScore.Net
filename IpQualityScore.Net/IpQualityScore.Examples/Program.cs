using IpQualityScore.Net.Requests;

var apiKey = "bKaxzWxXop1bJ0bRM6KyQZ1SCpKKJqeD";
var request = new EmailValidationRequest()
{
	Email = "hiznyaknikita1996@gmail.com",
	Fast = true,
	AbuseStrictness = 2,
	Strictness = 2,
	SuggestDomain = true,
	Timeout = 30
};

var IpQualityScore = new IpQualityScore.Net.IpQualityScore(apiKey);

try
{
	var result = await IpQualityScore.Email.Validate(request);
	Console.WriteLine($"Is email valid: {result.Valid}");
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}

Console.ReadKey();
