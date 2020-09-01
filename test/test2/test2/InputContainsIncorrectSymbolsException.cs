using System;
using System.Collections.Generic;
using System.Text;

namespace test2
{
    /// <summary>
    /// In case if input contains incorrect symbols.
    /// </summary>
    public class InputContainsIncorrectSymbolsException : Exception
    {
        public InputContainsIncorrectSymbolsException() { }
        public InputContainsIncorrectSymbolsException(string message) : base(message) { }
        public InputContainsIncorrectSymbolsException(string message, Exception inner)
            : base(message, inner) { }
        protected InputContainsIncorrectSymbolsException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
