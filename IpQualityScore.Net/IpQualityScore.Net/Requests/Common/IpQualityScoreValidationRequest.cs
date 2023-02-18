namespace IpQualityScore.Net.Requests.Common
{
	public abstract class IpQualityScoreValidationRequest
	{
		public bool? Fast { get; init; }
		public int? Timeout { get; init; }
		public int? Strictness { get; init; }
	}
}
