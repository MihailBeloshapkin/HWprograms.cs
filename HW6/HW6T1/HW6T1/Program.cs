using System;
using System.Collections.Generic;
using System.Text;

namespace HW6T1
{
    class Program
    {
        static void Main(string[] args)
        {
            var newList = new List<int>() {1, 2, 3, 4};
            newList = MapFilterAndFold.Map(newList, x => x + 30);
        }
    }
}
