using Microsoft.Extensions.DependencyInjection;

namespace IpQualityScore.Net.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddIpQualityScore(this IServiceCollection services, string apiKey)
		{
			services.AddIpQualityScoreClient(apiKey);
			services.AddSingleton<IpQualityScore>();

			return services;
		}
	}
}
