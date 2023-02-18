namespace IpQualityScore.Net.Validators.Common
{
    public interface IIpQualityScoreValidator<TResult, TRequest>
    {
        Task<TResult> Validate(TRequest request);
    }
}
