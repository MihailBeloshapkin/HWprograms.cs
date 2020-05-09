using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T2
{
    /// <summary>
    /// First hash function
    /// </summary>
    public class HashFunction1 : IHashFunction
    {
        /// <summary>
        /// This function returns index in array depending on input data and size of array
        /// </summary>
        /// <param name="value">Input data that we would like to add</param>
        /// <param name="sizeOfHash">Current hash table size</param>
        /// <returns>Index into array of lists</returns>
        public int HashFunction(string value)
        {
            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                result = (result + value[i]);
            }

            return result;
        }
    }
}