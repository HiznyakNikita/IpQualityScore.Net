using FluentValidation;

namespace IpQualityScore.Net.Requests
{
	public class StatsRequest
	{
		public string Country { get; set; }
		public DateOnly StartDate { get; set; }
		public DateOnly EndDate { get; set; }
		public IReadOnlyDictionary<string,string> CustomVariables { get; set; }
	}
}
