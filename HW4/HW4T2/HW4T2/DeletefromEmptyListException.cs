﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T2
{
    public class DeleteFromEmptyListException : Exception
    {
        public DeleteFromEmptyListException() { }
        public DeleteFromEmptyListException(string message) : base(message) { }
        public DeleteFromEmptyListException(string message, Exception inner)
        : base(message, inner) { }
        protected DeleteFromEmptyListException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
