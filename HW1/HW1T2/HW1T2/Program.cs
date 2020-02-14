using System;

namespace HW1T2
{
    class Program
    {
        private static int RecursiveCalculation(int value)
        {
            if (value <= 1)
            {
                return value;
            }
            else
            {
                return RecursiveCalculation(value - 1) + RecursiveCalculation(value - 2);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input value:");
            var inputString = Console.ReadLine();
            int value = int.Parse(inputString);
            Console.WriteLine("Result of calculation is: ");
            Console.WriteLine(RecursiveCalculation(value));
        }
    }
}
