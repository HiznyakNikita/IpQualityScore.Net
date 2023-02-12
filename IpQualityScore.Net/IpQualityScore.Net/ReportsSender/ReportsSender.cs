using AutoMapper;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;
using IpQualityScore.Common;
using IpQualityScore.Common.Responses;
using IpQualityScore.Common.Queries;
using static IpQualityScore.Net.Requests.ReportRequest;

namespace IpQualityScore.Net.Reports
{
	internal class ReportsSender: IReportsSender
	{
		private readonly IMapper _mapper;
		private readonly IIpQualityScoreApiClient _ipQualityScoreApiClient;

		public ReportsSender(IIpQualityScoreApiClient ipQualityScoreApiClient)
		{
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<ReportRequest, ReportQuery>();
				cfg.CreateMap<IpQualityScoreResponse, ReportResult>();
			});
			_mapper = mapperConfig.CreateMapper();
			_ipQualityScoreApiClient = ipQualityScoreApiClient;
		}

		public async Task<ReportResult> Send(ReportRequest request)
		{
			if (request == null)
				throw new ArgumentException(nameof(request));
			var validator = new ReportRequestValidator();
			var validationResult = validator.Validate(request);
			if (!validationResult.IsValid)
			{
				foreach (var failure in validationResult.Errors)
				{
					throw new Exception($"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
				}
			}

			var query = _mapper.Map<ReportQuery>(request);
			var response = await _ipQualityScoreApiClient.Get<ReportQuery, IpQualityScoreResponse>(query);
			var result = _mapper.Map<ReportResult>(response);

			return result;
		}
	}
}
