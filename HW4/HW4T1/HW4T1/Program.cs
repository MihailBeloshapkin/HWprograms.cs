using System;

namespace HW4T1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree("* (+ 2 2 ) 5");
            tree.Display();
            tree.Calculate();
        }
    }
}
