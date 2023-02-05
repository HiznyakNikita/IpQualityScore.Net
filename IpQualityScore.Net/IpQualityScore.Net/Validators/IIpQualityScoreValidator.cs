namespace IpQualityScore.Net.Validators
{
	public interface IIpQualityScoreValidator<TResult, TRequest>
	{
		Task<TResult> Validate(TRequest request);
	}
}
