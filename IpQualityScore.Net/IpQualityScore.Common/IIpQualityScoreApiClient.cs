﻿using IpQualityScore.Common.Queries.Common;
using IpQualityScore.Common.Responses.Common;

namespace IpQualityScore.Common
{
    public interface IIpQualityScoreApiClient
	{
		Task<TResponse> Get<TQuery, TResponse>(TQuery query, string[] routeParts = null)
			where TResponse : IpQualityScoreResponse
			where TQuery : IpQualityScoreQuery;
	}
}
