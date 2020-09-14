using System;
using System.Collections.Generic;
using System.Text;

namespace HW9T1
{
    /// <summary>
    /// This class compares two integer numbers.
    /// </summary>
    public class IntegerComparer : IComparer<int>
    {
        /// <summary>
        /// Compares two integer values.
        /// </summary>
        /// <returns>1 in case if the first is more than the second, 0 in case if two values are equal, and -1 in case if the first is less than the second.</returns>
        public int Compare(int firstValue, int secondValue)
            => firstValue > secondValue ? 1 : firstValue == secondValue ? 0 : -1;
    }
}
