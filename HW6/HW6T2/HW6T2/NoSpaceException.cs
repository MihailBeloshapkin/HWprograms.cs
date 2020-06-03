using System;
using System.Collections.Generic;
using System.Text;

namespace HW6T2
{
    class NoSpaceException : Exception
    {
        public NoSpaceException() { }
        public NoSpaceException(string message) : base(message) { }
        public NoSpaceException(string message, Exception inner)
        : base(message, inner) { }
        protected NoSpaceException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }

    }
}
