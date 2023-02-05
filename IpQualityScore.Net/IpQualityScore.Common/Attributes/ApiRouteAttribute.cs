namespace IpQualityScore.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	internal class ApiRouteAttribute : Attribute
	{
		public string Route { get; set; }

		public ApiRouteAttribute(string route) => Route = route;

	}
}
