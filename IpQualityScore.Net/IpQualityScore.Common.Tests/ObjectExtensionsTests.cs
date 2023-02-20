using IpQualityScore.Common.Extensions;
using Newtonsoft.Json;

namespace IpQualityScore.Common.Tests
{
	[TestClass]
	public class ObjectExtensionsTests
	{
		[TestMethod]
		public async Task ToUrlEncodedString_WhenObjectWithSimplePropsProvided_ThenReturnCorrectUrlEncodedString()
		{
			//Arrange
			var objectWithSimpleProps = new ObjectWithSimpleProps()
			{
				IntProp = 1,
				StringProp = "test",
				DoubleProp = 2.1,
				ObjProp1 = "obj1",
				ObjProp2 = 22
			};
			var expectedUrlEncodedString = "intProp=1&stringProp=test&doubleProp=2.1&objProp1=obj1&objProp2=22";
			//Act
			var resultUrlEncodedString = await objectWithSimpleProps.ToUrlEncodedString();
			//Assert
			Assert.AreEqual(expectedUrlEncodedString, resultUrlEncodedString);
		}

		[TestMethod]
		public async Task ToUrlEncodedString_WhenObjectWithSimplePropsProvided_ThenSkipNullAndEmptyPropsInUrlEncodedString()
		{
			//Arrange
			var objectWithSimpleProps = new ObjectWithSimpleProps()
			{
				IntProp = 1,
				StringProp = "",
				DoubleProp = 2.1,
				ObjProp1 = null,
				ObjProp2 = 22
			};
			var expectedUrlEncodedString = "intProp=1&doubleProp=2.1&objProp2=22";
			//Act
			var resultUrlEncodedString = await objectWithSimpleProps.ToUrlEncodedString();
			//Assert
			Assert.AreEqual(expectedUrlEncodedString, resultUrlEncodedString);
		}

		[TestMethod]
		public async Task ToUrlEncodedString_WhenObjectWithNestedObjectPropsProvided_ThenReturnCorrectUrlEncodedString()
		{
			//Arrange
			var objectWithNestedObjectProps = new ObjectWithNestedObjectProps()
			{
				MainProp = 1,
				Nested = new ObjectWithSimpleProps()
				{
					IntProp = 2,
					StringProp = "test",
					DoubleProp = 2.1
				}
			};
			var expectedUrlEncodedString = "mainProp=1&nested.intProp=2&nested.stringProp=test&nested.doubleProp=2.1";
			//Act
			var resultUrlEncodedString = await objectWithNestedObjectProps.ToUrlEncodedString();
			//Assert
			Assert.AreEqual(expectedUrlEncodedString, resultUrlEncodedString);
		}

		[TestMethod]
		public async Task ToUrlEncodedString_WhenObjectWithDictionaryPropsProvided_ThenReturnCorrectUrlEncodedString()
		{
			//Arrange
			var objectWithNestedObjectProps = new ObjectWithDictionaryProp()
			{
				IntProp = 1,
				DictProp = new Dictionary<string,string>()
				{
					{"key1", "value1"},
					{"key2", "value2"},
					{"key3", "value3"}
				}
			};
			var expectedUrlEncodedString = "intProp=1&dictProp.key1=value1&dictProp.key2=value2&dictProp.key3=value3";
			//Act
			var resultUrlEncodedString = await objectWithNestedObjectProps.ToUrlEncodedString();
			//Assert
			Assert.AreEqual(expectedUrlEncodedString, resultUrlEncodedString);
		}

		[TestMethod]
		public async Task ToUrlEncodedString_WhenObjectWithEnumerablePropsProvided_ThenReturnCorrectUrlEncodedString()
		{
			//Arrange
			var objectWithNestedObjectProps = new ObjectWithEnumerableProp()
			{
				IntProp = 1,
				EnumerableProp = new List<string>() {"value1", "value2", "value3"}
			};
			var expectedUrlEncodedString = "intProp=1&enumerableProp%5B0%5D=value1&enumerableProp%5B1%5D=value2&enumerableProp%5B2%5D=value3";
			//Act
			var resultUrlEncodedString = await objectWithNestedObjectProps.ToUrlEncodedString();
			//Assert
			Assert.AreEqual(expectedUrlEncodedString, resultUrlEncodedString);
		}

		private class ObjectWithNestedObjectProps
		{
			[JsonProperty("mainProp")]
			public int MainProp { get; set; }

			[JsonProperty("nested")]
			public ObjectWithSimpleProps Nested { get; set; }
		}

		private class ObjectWithSimpleProps
		{
			[JsonProperty("intProp")]
			public int IntProp { get; set; }

			[JsonProperty("stringProp")]
			public string StringProp { get; set; }

			[JsonProperty("doubleProp")]
			public double DoubleProp { get; set; }

			[JsonProperty("objProp1")]
			public object ObjProp1 { get; set; }

			[JsonProperty("objProp2")]
			public object ObjProp2 { get; set; }
		}

		private class ObjectWithDictionaryProp
		{
			[JsonProperty("intProp")]
			public int IntProp { get; set; }

			[JsonProperty("dictProp")]
			public IReadOnlyDictionary<string, string> DictProp { get; set; }
		}

		private class ObjectWithEnumerableProp
		{
			[JsonProperty("intProp")]
			public int IntProp { get; set; }

			[JsonProperty("enumerableProp")]
			public IReadOnlyCollection<string> EnumerableProp { get; set; }
		}
	}
}