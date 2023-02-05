using System.Runtime.Serialization;

namespace IpQualityScore.Net.Exceptions
{
	internal class IpQualityScoreException : Exception
	{
		public string RequestId { get; init; }

		public IpQualityScoreException(string requestId) : base()
		{
			RequestId = requestId;
		}

		public IpQualityScoreException(string requestId, string? message) : base(message)
		{
			RequestId = requestId;
		}

		public IpQualityScoreException(string requestId, string? message, Exception? innerException) : base(message, innerException)
		{
			RequestId = requestId;
		}

		protected IpQualityScoreException(string requestId, SerializationInfo info, StreamingContext context) : base(info, context)
		{
			RequestId = requestId;
		}
	}
}
