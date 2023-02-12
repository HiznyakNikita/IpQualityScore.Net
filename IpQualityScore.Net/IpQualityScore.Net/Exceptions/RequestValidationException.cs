using System.Runtime.Serialization;

namespace IpQualityScore.Net.Exceptions
{
	internal class RequestValidationException : Exception
	{
		public IReadOnlyDictionary<string, string> ValidationErrors{ get; init; }

		public RequestValidationException(IReadOnlyDictionary<string, string> validationErrors) : base()
		{
			ValidationErrors = validationErrors;
		}

		public RequestValidationException(IReadOnlyDictionary<string, string> validationErrors, string message) : base(message)
		{
			ValidationErrors = validationErrors;
		}

		public RequestValidationException(IReadOnlyDictionary<string, string> validationErrors, string message, Exception innerException) : base(message, innerException)
		{
			ValidationErrors = validationErrors;
		}

		protected RequestValidationException(IReadOnlyDictionary<string, string> validationErrors, SerializationInfo info, StreamingContext context) : base(info, context)
		{
			ValidationErrors = validationErrors;
		}
	}
}
