using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T2
{
    /// <summary>
    /// In case if we delete anything from empty list.
    /// </summary>
    public class AddDataThatIsAlreadyInTheListException : Exception
    {
        public AddDataThatIsAlreadyInTheListException() { }
        public AddDataThatIsAlreadyInTheListException(string message) : base(message) { }
        public AddDataThatIsAlreadyInTheListException(string message, Exception inner)
        : base(message, inner) { }
        protected AddDataThatIsAlreadyInTheListException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
