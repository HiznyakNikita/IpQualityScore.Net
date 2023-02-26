using Newtonsoft.Json;
using FluentValidation;
using Newtonsoft.Json.Converters;

namespace IpQualityScore.Net.Requests
{
	public class IpQualityScoreRequestApiRequest
	{
		public IpQualityScoreRequestType Type { get; init; }

		public int? Page { get; init; }

		public int? Limit { get; init; }

		public DateTime StartDate { get; init; }

		public DateTime StopDate { get; init; }

		public int? TrackerId { get; init; }

		public string DeviceId { get; init; }

		public int? MinFraudScore { get; init; }

		public int? MaxFraudScore { get; init; }

		public string IpAddress { get; init; }

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
