using AutoMapper;
using IpQualityScore.Common.Queries;
using IpQualityScore.Common;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using IpQualityScore.Common.Responses;
using IpQualityScore.Net.Providers.Contract;
using IpQualityScore.Net.Providers.Common;

namespace IpQualityScore.Net.Providers
{
	internal class StatsProvider : IpQualityScoreBaseProvider, IStatsProvider
	{
		private readonly IMapper _mapper;
		private readonly IIpQualityScoreApiClient _ipQualityScoreApiClient;

		public StatsProvider(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<StatsRequest, StatsQuery>()
				.ForMember("StartDate", opt => opt.MapFrom(c => c.StartDate.ToString("yyyy-MM-dd")))
				.ForMember("EndDate", opt => opt.MapFrom(c => c.EndDate.ToString("yyyy-MM-dd")))
				.ForMember("CustomVariables", opt => opt.MapFrom(c => c.CustomVariables.ToDictionary(cv => cv.Key, cv => cv.Value.ToString())));
				cfg.CreateMap<StatsResponse, StatsResult>();
			});
			_mapper = mapperConfig.CreateMapper();
			_ipQualityScoreApiClient = ipQualityScoreApiClient;
		}

		public async Task<StatsResult> Get(StatsRequest request)
		{
			if (request == null)
				throw new ArgumentException(nameof(request));

			var query = _mapper.Map<StatsQuery>(request);
			var response = await _ipQualityScoreApiClient.Get<StatsQuery, StatsResponse>(query, format: null);
			var result = _mapper.Map<StatsResult>(response);

			return result;
		}
	}
}
