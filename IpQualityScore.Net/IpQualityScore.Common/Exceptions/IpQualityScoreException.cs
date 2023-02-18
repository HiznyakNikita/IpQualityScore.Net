using System.Runtime.Serialization;

namespace IpQualityScore.Common.Exceptions
{
	internal class IpQualityScoreException : Exception
	{
		public string RequestId { get; init; }
		public string[] Errors { get; set; }

		public IpQualityScoreException(string requestId) : base()
		{
			RequestId = requestId;
		}

		public IpQualityScoreException(string requestId, string message) : base(message)
		{
			RequestId = requestId;
		}

		public IpQualityScoreException(string requestId, string[] errors, string message) : base(message)
		{
			RequestId = requestId;
			Errors = errors;
		}

		public IpQualityScoreException(string requestId, string[] errors, string message, Exception innerException) : base(message, innerException)
		{
			RequestId = requestId;
			Errors = errors;
		}

		protected IpQualityScoreException(string requestId, string[] errors, SerializationInfo info, StreamingContext context) : base(info, context)
		{
			RequestId = requestId;
			Errors = errors;
		}
	}
}
