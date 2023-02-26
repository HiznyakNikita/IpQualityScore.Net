using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;

namespace IpQualityScore.Net.Providers.Contract
{
	public interface IIpQualityScoreRequestsProvider
	{
		Task<IpQualityScoreRequestApiResult> Get(IpQualityScoreRequestApiRequest request);
	}
}
