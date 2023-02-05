using AutoMapper;
using IpQualityScore.Net.Exceptions;
using IpQualityScore.Net.Extensions;
using IpQualityScore.Net.Queries;
using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Responses;
using IpQualityScore.Net.Results;
using Newtonsoft.Json;

namespace IpQualityScore.Net.Reports
{
	internal class ReportsSender: IReportsSender
	{
		private const string _path = "report";
		private readonly string _url;
		private readonly IMapper _mapper;

		public ReportsSender(string apiKey, string baseUrl)
		{
			_url = $"{baseUrl}{_path}/{apiKey}";
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<ReportRequest, ReportQuery>();
				cfg.CreateMap<IpQualityScoreResponse, ReportResult>();
			});
			_mapper = mapperConfig.CreateMapper();
		}

		public async Task<ReportResult> Send(ReportRequest request)
		{
			if (request == null)
				throw new ArgumentException(nameof(request));

			var query = _mapper.Map<ReportQuery>(request);
			var client = new HttpClient();
			var apiRequest = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"{_url}?{await query.ToUrlEncodedString()}")
			};
			using (var response = await client.SendAsync(apiRequest))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<IpQualityScoreResponse>(body);
				if (result is null)
					throw new Exception($"Error occurred while report send");
				if (!result.Success.GetValueOrDefault())
				{
					throw new IpQualityScoreException(result.RequestId, result.Message);
				}

				return _mapper.Map<ReportResult>(result);
			}
		}
	}
}
