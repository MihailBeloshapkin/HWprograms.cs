using System;
using System.Collections.Generic;
using System.Text;

namespace HW6T1
{
    /// <summary>
    /// This class contains three special list functions
    /// </summary>
    public static class MapFilterAndFold
    {
        /// <summary>
        /// Get list and function, transform list and return new variant.
        /// </summary>
        /// <param name="list">List of integer numbers</param>
        /// <param name="function">Input function</param>
        /// <returns>transformed list</returns>
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            var newList = new List<int>();
            
            foreach (int element in list)
            {
                newList.Add(function(element));
            }

            return newList;
        }

        /// <summary>
        /// Get list and bool function and returns list of elements for which the value is true. 
        /// </summary>
        /// <param name="list">Input list</param>
        /// <param name="function">Input bool function</param>
        /// <returns>List of elements for which the result of function is true</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            var newList = new List<int>();

            foreach (int element in list)
            {
                if (function(element))
                {
                    newList.Add(element);
                }
            }

            return newList;
        }

        /// <summary>
        /// Get list, current value and function and apply function for each element and current. 
        /// </summary>
        /// <param name="list">Input list</param>
        /// <param name="current">Current value that we are going to change</param>
        /// <param name="function">Input function</param>
        /// <returns>Current value after applying the function</returns>
        public static int Fold(List<int> list, int current, Func<int, int, int> function)
        {
            foreach (int element in list)
            {
                current = function(element, current);
            }

            return current;
        }
    }
}
