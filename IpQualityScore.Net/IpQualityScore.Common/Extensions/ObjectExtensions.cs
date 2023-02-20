using Newtonsoft.Json.Linq;
using System.Globalization;

namespace IpQualityScore.Common.Extensions
{
	public static class ObjectExtensions
	{
		public static async Task<string> ToUrlEncodedString(this object obj)
		{
			var keyValueContent = obj.ToKeyValue();
			var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);
			var urlEncodedString = await formUrlEncodedContent.ReadAsStringAsync();

			return urlEncodedString;
		}

		private static IDictionary<string, string> ToKeyValue(this object obj)
		{
			if (obj == null)
			{
				return null;
			}

			JToken token = obj as JToken;
			if (token == null)
			{
				return ToKeyValue(JObject.FromObject(obj));
			}

			if (token.HasValues)
			{
				var contentData = new Dictionary<string, string>();
				foreach (var child in token.Children().ToList())
				{
					var childContent = child.ToKeyValue();
					if (childContent != null)
					{
						contentData = contentData.Concat(childContent)
												 .ToDictionary(k => k.Key, v => v.Value);
					}
				}

				return contentData;
			}

			var jValue = token as JValue;
			if (jValue?.Value == null)
				return null;

			var value = jValue?.Type == JTokenType.Date ?
							jValue?.ToString("o", CultureInfo.InvariantCulture) :
							jValue?.ToString(CultureInfo.InvariantCulture);

			if (string.IsNullOrEmpty(value))
				return null;

			return new Dictionary<string, string> { { token.Path, value } };
		}
	}
}
