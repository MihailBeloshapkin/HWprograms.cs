using System;

namespace HW6T1
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Add(1);
            list.Add(2);
            list.Display();
            list.Delete();
            list.Display();
        }
    }
}
