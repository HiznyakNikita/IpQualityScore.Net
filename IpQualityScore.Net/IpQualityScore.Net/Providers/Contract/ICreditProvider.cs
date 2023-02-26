using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;

namespace IpQualityScore.Net.Providers.Contract
{
    public interface ICreditProvider
    {
        Task<CreditResult> Get(CreditRequest request);
    }
}
