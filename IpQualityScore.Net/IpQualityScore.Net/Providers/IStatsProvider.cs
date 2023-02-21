using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;

namespace IpQualityScore.Net.Providers
{
	public interface IStatsProvider
	{
		Task<StatsResult> Get(StatsRequest request);
	}
}
