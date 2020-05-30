using System;

namespace vector
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 3, 0, 0, 1, 0, 0, 0, 9, 8};
            Vector MyVector = new Vector();
            MyVector.SaveList(array);
            MyVector.Display();
        }
    }
}
