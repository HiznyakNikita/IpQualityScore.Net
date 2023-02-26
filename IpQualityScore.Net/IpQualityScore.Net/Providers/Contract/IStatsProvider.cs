using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;

namespace IpQualityScore.Net.Providers.Contract
{
	public interface IStatsProvider
	{
		Task<StatsResult> Get(StatsRequest request);
	}
}
