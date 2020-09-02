using System;

namespace HW9T1
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new AlternativeSet<int>(new IntegerComparer()) { 15, -7, 19, 25, 128, -72, 54, 1992 };
            int[] array = new int[8] { 15, -7, 19, 25, 128, -72, 54, 1992 };

            set.ExceptWith(array);
            set.CopyTo(array, 0);
            set.Add(30);
            set.Add(239);
            set.Remove(239);
        }
    }
}
