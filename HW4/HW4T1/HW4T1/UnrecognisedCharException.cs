using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    class UnrecognisedCharException : Exception
    {
        public UnrecognisedCharException() { }
        public UnrecognisedCharException(string message) : base(message) { }
        public UnrecognisedCharException(string message, Exception inner)
        : base(message, inner) { }
        protected UnrecognisedCharException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
