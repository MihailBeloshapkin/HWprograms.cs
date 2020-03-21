using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T2
{
    interface IHashFunction
    {
        /// <summary>
        /// This function returns index in array depending on input data and size of array
        /// </summary>
        /// <param name="value">Input data that we want to add</param>
        /// <param name="sizeOfHash">Size of hash table</param>
        /// <returns>Index in array of lists</returns>
        int HashFunction(string value, int sizeOfHash);
    }
}
