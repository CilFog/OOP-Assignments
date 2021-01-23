﻿using System;
using System.Runtime.Serialization;

namespace TREON_BarcodeSystem.Exceptions
{
    public class ProductNotActiveException : Exception
    {
        public ProductNotActiveException()
        {
        }

        public ProductNotActiveException(string message) : base(message)
        {
        }

        public ProductNotActiveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductNotActiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
