using System;
using System.Runtime.Serialization;

namespace PriceAndDistanceRange
{
    [Serializable]
    public class DistanceOutOfRangeException : Exception
    {
        public DistanceOutOfRangeException()
        {
        }

        public DistanceOutOfRangeException(string message) : base(message)
        {
        }

        public DistanceOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DistanceOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}