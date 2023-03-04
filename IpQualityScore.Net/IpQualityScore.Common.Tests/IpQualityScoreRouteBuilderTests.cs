using IpQualityScore.Common.Attributes;
using IpQualityScore.Common.Exceptions;
using IpQualityScore.Common.Queries.Common;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Tests
{
	[TestClass]
	public class IpQualityScoreRouteBuilderTests
	{
		private const string _baseUrl = "https://myapi.com/api";
		private const string _apiKey = "12345";

		[TestMethod]
		public void Build_WhenQueryObjectHasNoRouteAttribute_ThrowsException()
		{
			//Arrange
			var query = new TestQueryObject();
			//Act
			//Assert
			Assert.ThrowsExceptionAsync<IpQualityScoreException>(() => IpQualityScoreRouteBuilder.Build(_baseUrl, _apiKey, query));
		}

		[TestMethod]
		public async Task Build_WhenQueryObjectHasRouteAttribute_UseThisRouteAttributeInsideResultRoute()
		{
			//Arrange
			var query = new TestQueryObjectWithRouteAttribute();
			var expectedRoute = $"{_baseUrl}/json/testroute/{_apiKey}";
			//Act
			var resultRoute = await IpQualityScoreRouteBuilder.Build(_baseUrl, _apiKey, query);
			//Assert
			Assert.AreEqual(expectedRoute, resultRoute);
		}

		[DataRow("json", $"{_baseUrl}/json/testroute/{_apiKey}")]
		[DataRow(null, $"{_baseUrl}/{_apiKey}/testroute")]
		[TestMethod]
		public async Task Build_WhenFormatSpecified_UseThisFormatInsideResultRoute(string format, string expectedRoute)
		{
			//Arrange
			var query = new TestQueryObjectWithRouteAttribute();
			//Act
			var resultRoute = await IpQualityScoreRouteBuilder.Build(_baseUrl, _apiKey, query, format: format);
			//Assert
			Assert.AreEqual(expectedRoute, resultRoute);
		}

		[DataRow(new string[] { "my", "specific", "route" }, $"{_baseUrl}/json/testroute/{_apiKey}/my/specific/route")]
		[DataRow(new string[] { "my", null, "route" }, $"{_baseUrl}/json/testroute/{_apiKey}/my/route")]
		[DataRow(new string[] { "my", "", "route" }, $"{_baseUrl}/json/testroute/{_apiKey}/my/route")]
		[DataRow(new string[0], $"{_baseUrl}/json/testroute/{_apiKey}")]
		[DataRow(null, $"{_baseUrl}/json/testroute/{_apiKey}")]
		[TestMethod]
		public async Task Build_WhenRoutePartsSpecified_UseThisRoutePartsInsideResultRoute(string[] routeParts, string expectedRoute)
		{
			//Arrange
			var query = new TestQueryObjectWithRouteAttribute();
			//Act
			var resultRoute = await IpQualityScoreRouteBuilder.Build(_baseUrl, _apiKey, query, routeParts: routeParts);
			//Assert
			Assert.AreEqual(expectedRoute, resultRoute);
		}

		[TestMethod]
		public async Task Build_WhenQueryObjectContainsFields_UseThisFieldsAsUrlEncodedQueryParametersInsideResultRoute()
		{
			//Arrange
			var query = new TestQueryObjectWithRouteAttributeAndFields()
			{
				Field1 = "value1",
				Field2 = 2
			};
			var expectedRoute = $"{_baseUrl}/json/testroute/{_apiKey}?field1={query.Field1}&field2={query.Field2}";
			//Act
			var resultRoute = await IpQualityScoreRouteBuilder.Build(_baseUrl, _apiKey, query);
			//Assert
			Assert.AreEqual(expectedRoute, resultRoute);
		}

		class TestQueryObject: IpQualityScoreQuery { };

		[ApiRoute("testroute")]
		class TestQueryObjectWithRouteAttribute : IpQualityScoreQuery { };

		[ApiRoute("testroute")]
		class TestQueryObjectWithRouteAttributeAndFields : IpQualityScoreQuery 
		{
			[JsonProperty("field1")]
			public string Field1 { get; set; }

			[JsonProperty("field2")]
			public int Field2 { get; set; }
		};
	}
}
