using AutoMapper;
using IpQualityScore.Common.Queries;
using IpQualityScore.Common.Responses;
using IpQualityScore.Common;
using IpQualityScore.Net.Providers.Contract;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using IpQualityScore.Net.Providers.Common;

namespace IpQualityScore.Net.Providers
{
	internal class CreditProvider : IpQualityScoreBaseProvider, ICreditProvider
	{
		private readonly IMapper _mapper;
		private readonly IIpQualityScoreApiClient _ipQualityScoreApiClient;

		public CreditProvider(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<CreditRequest, CreditQuery>();
				cfg.CreateMap<CreditResponse, CreditResult>();
			});
			_mapper = mapperConfig.CreateMapper();
			_ipQualityScoreApiClient = ipQualityScoreApiClient;
		}

		public async Task<CreditResult> Get(CreditRequest request)
		{
			if (request == null)
				throw new ArgumentException(null, nameof(request));

			var query = _mapper.Map<CreditQuery>(request);
			var response = await _ipQualityScoreApiClient.Get<CreditQuery, CreditResponse>(query);
			var result = _mapper.Map<CreditResult>(response);

			return result;
		}
	}
}
