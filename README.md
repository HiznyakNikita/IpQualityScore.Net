[![Build status](https://ci.appveyor.com/api/projects/status/6gugu36aq0befp0r/branch/main?svg=true)](https://ci.appveyor.com/project/HiznyakNikita/ipqualityscore-net/branch/main)

# IpQualityScore.Net

The IpQualityScore.Net helps developers build applications that integrate with IpQualityScore.

## Nuget

Nuget package available [here](https://www.nuget.org/packages/IpQualityScore.Net/)

`dotnet add package IpQualityScore.Net --version 1.0.4`

`Install-Package IpQualityScore.Net`

## Supported api's

- [Proxy Detection API | VPN Detection API](https://www.ipqualityscore.com/documentation/proxy-detection/overview)
- [Email Validation API](https://www.ipqualityscore.com/documentation/email-validation/overview)
- [Phone Number Validation API](https://www.ipqualityscore.com/documentation/phone-number-validation-api/overview)
- [Malicious URL Scanner API](https://www.ipqualityscore.com/documentation/malicious-url-scanner-api/overview)
- [Fraud Reporting API](https://www.ipqualityscore.com/documentation/fraud-reporting/overview)
- [Credit Usage API](https://www.ipqualityscore.com/documentation/usage/overview)

## Usage

Add IpQualityScore.Net nuget to your project. And add IpQualityScore services.
```c#
var apiKey = "my_api_key";
var serviceProvider = new ServiceCollection()
			.AddIpQualityScore(apiKey)
			.BuildServiceProvider();
var IpQualityScore = serviceProvider
	.GetService< IpQualityScore.Net.IpQualityScore>();
```

Use api's described above in following way:

```c#
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
```

Please see `IpQualityScore.Examples` project for more examples.
