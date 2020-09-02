using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T2
{
    /// <summary>
    /// In case if input position is negative or more than size of list.
    /// </summary>
    public class IncorrectInputPositionException : Exception
    {
        public IncorrectInputPositionException() { }
        public IncorrectInputPositionException(string message) : base(message) { }
        public IncorrectInputPositionException(string message, Exception inner)
            : base(message, inner) { }
        protected IncorrectInputPositionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
