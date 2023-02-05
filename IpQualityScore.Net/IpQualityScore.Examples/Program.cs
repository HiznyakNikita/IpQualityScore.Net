var apiKey = "";
var email = "";

var IpQualityScore = new IpQualityScore.Net.IpQualityScore(apiKey);

try
{
	var result = await IpQualityScore.Email.Validate(email);
	Console.WriteLine($"Is email valid: {result.Valid}");
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}

Console.ReadKey();
