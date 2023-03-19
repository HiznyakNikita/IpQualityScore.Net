using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using IpQualityScore.Net.Results.Common;

namespace IpQualityScore.Net.Providers.Contract
{
	public interface IIpQualityScoreRequestListProvider
	{
		Task<IpQualityScoreRequestApiResult<TType>> Get<TType>(IpQualityScoreRequestApiRequest request)
			where TType : IpQualityScoreRequestResult, new();
	}
}
