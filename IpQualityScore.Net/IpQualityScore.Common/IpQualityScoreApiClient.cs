using IpQualityScore.Common.Attributes;
using IpQualityScore.Common.Exceptions;
using IpQualityScore.Common.Extensions;
using IpQualityScore.Common.Queries.Common;
using IpQualityScore.Common.Responses.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common
{
    internal class IpQualityScoreApiClient : IIpQualityScoreApiClient
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;
		private const string _baseUrl = "https://ipqualityscore.com/api/json";

		public IpQualityScoreApiClient(string apiKey)
		{
			_httpClient = new HttpClient();
			_apiKey = apiKey;
		}

		public async Task<TResponse> Get<TQuery, TResponse>(TQuery query, string[] routeParts = null)
			where TResponse : IpQualityScoreResponse
			where TQuery: IpQualityScoreQuery
		{
			var route = GetRouteForQuery(query);
			var requestUrl = routeParts != null && routeParts.Any()
				? $"{_baseUrl}/{route}/{_apiKey}/{string.Join("/", routeParts)}?{await query.ToUrlEncodedString()}"
				: $"{_baseUrl}/{route}/{_apiKey}?{await query.ToUrlEncodedString()}";

			var apiRequest = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(requestUrl)
			};
			using (var response = await _httpClient.SendAsync(apiRequest))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();

				var ipQualityScoreResponse = JsonConvert.DeserializeObject<TResponse>(body);
				if (ipQualityScoreResponse is null)
					throw new Exception($"Error occurred while request to: {requestUrl}");
				if (!ipQualityScoreResponse.Success.GetValueOrDefault())
				{
					throw new IpQualityScoreException(ipQualityScoreResponse.RequestId, ipQualityScoreResponse.Errors, ipQualityScoreResponse.Message);
				}

				return ipQualityScoreResponse;
			}
		}

		private string GetRouteForQuery<TQuery>(TQuery query)
			where TQuery: IpQualityScoreQuery
		{
			var attribute = query.GetType().GetCustomAttributes(false)
				.FirstOrDefault(a => a is ApiRouteAttribute);
			var route = (attribute as ApiRouteAttribute)?.Route;

			return route;
		}
	}
}
