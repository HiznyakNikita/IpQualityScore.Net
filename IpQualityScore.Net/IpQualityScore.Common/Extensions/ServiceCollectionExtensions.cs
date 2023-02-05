using IpQualityScore.Common;
using Microsoft.Extensions.DependencyInjection;

namespace IpQualityScore.Net.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddIpQualityScoreClient(this IServiceCollection services, string apiKey)
		{
			services.AddSingleton< IIpQualityScoreApiClient, IpQualityScoreApiClient>(x => {return new IpQualityScoreApiClient(apiKey);});
		}
	}
}
