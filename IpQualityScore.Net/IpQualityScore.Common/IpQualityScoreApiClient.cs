using IpQualityScore.Common.Exceptions;
using IpQualityScore.Common.Queries.Common;
using IpQualityScore.Common.Responses.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common
{
	internal class IpQualityScoreApiClient : IIpQualityScoreApiClient
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;
		private const string _baseUrl = "https://ipqualityscore.com/api";

		public IpQualityScoreApiClient(string apiKey)
		{
			_httpClient = new HttpClient();
			_apiKey = apiKey;
		}

		public async Task<TResponse> Get<TQuery, TResponse>(TQuery query, string[] routeParts = null, string format = "json")
			where TResponse : IpQualityScoreResponse
			where TQuery: IpQualityScoreQuery
		{
			try
			{
				var requestUrl = await IpQualityScoreRouteBuilder.Build(_baseUrl, _apiKey, query, routeParts, format);
				var apiRequest = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri(requestUrl)
				};

				using var response = await _httpClient.SendAsync(apiRequest);
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
			catch(HttpRequestException ex)
			{
				throw new IpQualityScoreException(null, null, $"Error while request to ipqualityscore API for {query.GetType().Name}", ex);
			}
		}
	}
}
