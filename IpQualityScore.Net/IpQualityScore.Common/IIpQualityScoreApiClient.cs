using IpQualityScore.Common.Queries;
using IpQualityScore.Common.Responses;

namespace IpQualityScore.Common
{
	public interface IIpQualityScoreApiClient
	{
		Task<TResponse> Get<TQuery, TResponse>(TQuery query, string[] routeParts = null)
			where TResponse : IpQualityScoreResponse
			where TQuery : IpQualityScoreQuery;
	}
}
