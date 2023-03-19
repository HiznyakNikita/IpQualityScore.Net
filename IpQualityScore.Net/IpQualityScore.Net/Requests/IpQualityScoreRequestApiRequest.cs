using Newtonsoft.Json;
using FluentValidation;
using Newtonsoft.Json.Converters;

namespace IpQualityScore.Net.Requests
{
	public class IpQualityScoreRequestApiRequest
	{
		/// <summary>
		/// Request type.
		/// </summary>
		public IpQualityScoreRequestType Type { get; init; }

		/// <summary>
		/// The page number you are requesting. Defaults to 1 if not specified. Used to retrieve more results than the limit provides.
		/// </summary>
		public int? Page { get; init; }

		/// <summary>
		/// Allows you to specify how many results will be returned with your query up to a maximum of 250. Defaults to 25.
		/// </summary>
		public int? Limit { get; init; }

		/// <summary>
		/// Fetches records newer than or equal to the date specified.
		/// </summary>
		public DateTime StartDate { get; init; }

		/// <summary>
		/// Fetches records older than or equal to the date specified.
		/// </summary>
		public DateTime StopDate { get; init; }

		/// <summary>
		/// This is an optional parameter used to narrow the scope of a variable lookup for a device tracker type.
		/// </summary>
		public int? TrackerId { get; init; }

		/// <summary>
		/// This is an optional parameter to search all matching device ID queries with device fingerprinting.
		/// </summary>
		public string DeviceId { get; init; }

		/// <summary>
		/// This is an optional parameter to limit results to only contain fraud scores greater than or equal to this number.
		/// </summary>
		public int? MinFraudScore { get; init; }

		/// <summary>
		/// This is an optional parameter to limit results to only contain fraud scores less than or equal to this number.
		/// </summary>
		public int? MaxFraudScore { get; init; }

		/// <summary>
		/// This is an optional parameter to search all matching IP address queries for "proxy", "devicetracker", and "mobiletracker" types.	
		/// </summary>
		public string IpAddress { get; init; }

		/// <summary>
		/// Your custom variables (as defined in account settings).
		/// </summary>
		[JsonExtensionData]
		public IReadOnlyDictionary<string, string> CustomVariables { get; init; }

	}

	public class IpQualityScoreRequestApiRequestValidator : AbstractValidator<IpQualityScoreRequestApiRequest>
	{
		public IpQualityScoreRequestApiRequestValidator()
		{
			RuleFor(x => x.Type).NotEmpty().IsInEnum();
			RuleFor(x => x.Page).GreaterThanOrEqualTo(1).When(p => p.Page.HasValue);
			RuleFor(x => x.Limit).GreaterThanOrEqualTo(1).When(p => p.Limit.HasValue);
			RuleFor(x => x.Limit).LessThanOrEqualTo(250).When(p => p.Limit.HasValue);
			RuleFor(x => x.MinFraudScore).GreaterThanOrEqualTo(0).When(p => p.MinFraudScore.HasValue);
			RuleFor(x => x.MinFraudScore).LessThanOrEqualTo(100).When(p => p.MinFraudScore.HasValue);
			RuleFor(x => x.MaxFraudScore).GreaterThanOrEqualTo(0).When(p => p.MaxFraudScore.HasValue);
			RuleFor(x => x.MaxFraudScore).LessThanOrEqualTo(100).When(p => p.MaxFraudScore.HasValue);
		}
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum IpQualityScoreRequestType
	{
		Proxy,
		Email,
		Phone,
		DeviceTracker,
		MobileTracker
	}
}
