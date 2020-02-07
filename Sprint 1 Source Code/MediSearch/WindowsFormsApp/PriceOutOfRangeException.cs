using System;
using System.Runtime.Serialization;

namespace PriceAndDistanceRange
{
    [Serializable]
    public class PriceOutOfRangeException : Exception
    {
        public PriceOutOfRangeException()
        {
        }

        public PriceOutOfRangeException(string message) : base(message)
        {
        }

        public PriceOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PriceOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}