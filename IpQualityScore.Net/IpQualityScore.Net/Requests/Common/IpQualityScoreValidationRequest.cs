namespace IpQualityScore.Net.Requests.Common
{
	public abstract class IpQualityScoreValidationRequest
	{
		/// <summary>
		/// When this parameter is enabled our API will not perform an SMTP check with the mail service provider, which greatly increases the API speed. Syntax and DNS checks are still performed on the email address as well as our disposable email detection service. This option is intended for services that require decision making in a time sensitive manner.
		/// </summary>
		public bool? Fast { get; init; }

		/// <summary>
		/// 	Maximum number of seconds to wait for a reply from a mail service provider. If your implementation requirements do not need an immediate response, we recommend bumping this value to 20. Any results which experience a connection timeout will return the "timed_out" variable as true. Default value is 7 seconds.
		/// </summary>
		public int? Timeout { get; init; }

		/// <summary>
		/// Sets how strictly spam traps and honeypots are detected by our system, depending on how comfortable you are with identifying emails suspected of being a spam trap. 0 is the lowest level which will only return spam traps with high confidence. Strictness levels above 0 will return increasingly more strict results, with level 2 providing the greatest detection rates.
		/// </summary>
		public int? Strictness { get; init; }
	}
}
