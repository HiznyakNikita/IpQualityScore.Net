using IpQualityScore.Net.Requests;
using IpQualityScore.Net.Results;

namespace IpQualityScore.Net.Reports
{
	public interface IReportsSender
	{
		Task<ReportResult> Send(ReportRequest request);
	}
}
