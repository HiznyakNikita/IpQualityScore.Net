using IpQualityScore.Common.Attributes;
using IpQualityScore.Common.Exceptions;
using IpQualityScore.Common.Extensions;
using IpQualityScore.Common.Queries.Common;

namespace IpQualityScore.Common
{
	internal static class IpQualityScoreRouteBuilder
	{
		private static readonly string[] _allowedFormats = new[] { "json" };
		public static async Task<string> Build<TQuery>(string baseUrl, string apiKey, TQuery query, string[] routeParts = null, string format = "json")
			where TQuery : IpQualityScoreQuery
		{
			string requestUrl;
			string route = GetRouteForQuery(query);
			if (string.IsNullOrEmpty(route))
				throw new IpQualityScoreException(null, $"Incorrect route for entity: {query.GetType().Name}");

			routeParts = routeParts != null ? routeParts.Where(r => !string.IsNullOrEmpty(r)).ToArray() : null;
			var urlEncodedQuery = await query.ToUrlEncodedString();
			var queryString = string.IsNullOrEmpty(urlEncodedQuery) ? "" : $"?{urlEncodedQuery}";

			if (string.IsNullOrEmpty(format))
			{
				requestUrl = routeParts != null && routeParts.Any()
					? $"{baseUrl}/{apiKey}/{route}/{string.Join("/", routeParts)}{queryString}"
					: $"{baseUrl}/{apiKey}/{route}{queryString}";
			}
			else if (_allowedFormats.Contains(format))
			{
				requestUrl = routeParts != null && routeParts.Any()
					? $"{baseUrl}/{format}/{route}/{apiKey}/{string.Join("/", routeParts)}{queryString}"
					: $"{baseUrl}/{format}/{route}/{apiKey}{queryString}";
			}
			else
				throw new IpQualityScoreException(null, $"Format {format} not supported");

			if (string.IsNullOrEmpty(requestUrl))
				throw new IpQualityScoreException(null, $"Incorrect request url for entity: {query.GetType().Name}");

			return requestUrl;
		}
		private static string GetRouteForQuery<TQuery>(TQuery query)
			where TQuery : IpQualityScoreQuery
		{
			var attribute = query.GetType().GetCustomAttributes(false)
				.FirstOrDefault(a => a is ApiRouteAttribute);
			var route = (attribute as ApiRouteAttribute)?.Route;

			return route;
		}
	}
}
