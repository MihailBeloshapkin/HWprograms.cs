using System;

namespace HW1T1
{
    class Program
    {
        private static int FactorialCalculation(int value)
        {
            if (value <= 1)
            {
                return 1;
            }
            return value * FactorialCalculation(value - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input value:");
            var inputString = Console.ReadLine();
            int value = int.Parse(inputString);
            Console.WriteLine("Result of calculation is: ");
            Console.WriteLine(FactorialCalculation(value));
        }
    }
}
