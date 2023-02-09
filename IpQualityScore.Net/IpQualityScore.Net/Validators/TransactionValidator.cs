using AutoMapper;
using IpQualityScore.Common.Queries;
using IpQualityScore.Common.Responses;
using IpQualityScore.Common;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;

namespace IpQualityScore.Net.Validators
{
	internal class TransactionValidator : IIpQualityScoreValidator<TransactionRiskScoringResult, TransactionRiskScoringRequest>
	{
		private readonly IMapper _mapper;
		private readonly IIpQualityScoreApiClient _ipQualityScoreApiClient;

		public TransactionValidator(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<TransactionScoringResponse, TransactionRiskScoringResult>();
				cfg.CreateMap<TransactionDetailsResponse, TransactionDetails>();
				cfg.CreateMap<TransactionRiskScoringRequest, TransactionRiskScoringQuery>();
			});
			_mapper = mapperConfig.CreateMapper();

			_ipQualityScoreApiClient = ipQualityScoreApiClient;
		}

		public async Task<TransactionRiskScoringResult> Validate(TransactionRiskScoringRequest request)
		{
			if (request == null)
				throw new ArgumentException(nameof(request));

			var query = _mapper.Map<TransactionRiskScoringQuery>(request);
			var response = await _ipQualityScoreApiClient.Get<TransactionRiskScoringQuery, TransactionScoringResponse>(query, new[] { request.IpAddress });
			var result = _mapper.Map<TransactionRiskScoringResult>(response);

			return result;
		}
	}
}
