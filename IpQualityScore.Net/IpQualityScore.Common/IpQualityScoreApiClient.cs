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
			string requestUrl;
			string route;
			if (string.IsNullOrEmpty(format))
			{
				route = GetRouteForQuery(query);
				requestUrl = routeParts != null && routeParts.Any()
					? $"{_baseUrl}/{_apiKey}/{route}/{string.Join("/", routeParts)}?{await query.ToUrlEncodedString()}"
					: $"{_baseUrl}/{_apiKey}/{route}?{await query.ToUrlEncodedString()}";
			}
			else if (format == "json")
			{
				route = GetRouteForQuery(query);
				requestUrl = routeParts != null && routeParts.Any()
					? $"{_baseUrl}/{format}/{route}/{_apiKey}/{string.Join("/", routeParts)}?{await query.ToUrlEncodedString()}"
					: $"{_baseUrl}/{format}/{route}/{_apiKey}?{await query.ToUrlEncodedString()}";
			}
			else
				throw new IpQualityScoreException(null, $"Format {format} not supported");

			if (!string.IsNullOrEmpty(route) && !string.IsNullOrEmpty(requestUrl))
			{
				var apiRequest = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri(requestUrl)
				};

				try
				{
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
				catch(HttpRequestException ex)
				{
					throw new IpQualityScoreException(null, null, $"Error while request to ipqualityscore API request url {requestUrl}", ex);
				}
			}
			else
				throw new IpQualityScoreException(null, $"Incorrect route: {route} or request url {requestUrl}");
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
