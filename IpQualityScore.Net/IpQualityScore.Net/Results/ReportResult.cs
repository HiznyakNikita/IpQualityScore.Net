using IpQualityScore.Net.Results.Common;

namespace IpQualityScore.Net.Results
{
	public class ReportResult: IpQualityScoreRequestResult
	{
		public bool? Success { get; set; }
		public string Message { get; set; }
	}
}
