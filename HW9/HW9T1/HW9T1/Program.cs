using System;

namespace HW9T1
{
    class Program
    {
        static void Main(string[] args)
        {
            AlternativeISet<int> set = new AlternativeISet<int>(new IntegerComparer()) { 15, -7, 19, 25, 128, -72, 54, 1992 };
            int[] array = new int[6];
            
            set.SymmetricExceptWith(new int[4] { 15, -7, 1992, 30});
            set.CopyTo(array, 0);
            set.Add(30);
            set.Add(239);
            set.Remove(239);
        }
    }
}
