using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T2
{
    /// <summary>
    /// Interface for hash function.
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// This function returns index in array depending on input data and size of array
        /// </summary>
        /// <param name="value">Input data that we want to add</param>
        /// <returns>Index in array of lists</returns>
        public int HashFunction(string value);
    }
}
