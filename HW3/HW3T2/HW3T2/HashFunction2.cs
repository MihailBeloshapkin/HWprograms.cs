using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T2
{
    /// <summary>
    /// More one variant of hash function.
    /// </summary>
    public class HashFunction2 : IHashFunction
    {
        /// <summary>
        /// This function returns index in array depending on input data and size of array
        /// </summary>
        /// <param name="value">Input data that we would like to add</param>
        /// <returns>Index into array of lists</returns>
        public int HashFunction(string value)
        {
            return value[0];
        }
    }
}