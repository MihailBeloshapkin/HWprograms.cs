using System;

namespace HW1T2
{
    class Program
    {
        private static int IterCalculation(int value)
        {
            int[] fibanacciArray = new int[3] { 1, 1, 0 };
            for (int iter = 0; iter < value - 2; iter++)
            {
                fibanacciArray[2] = fibanacciArray[0] + fibanacciArray[1];
                fibanacciArray[0] = fibanacciArray[1];
                fibanacciArray[1] = fibanacciArray[2];
            }
            return fibanacciArray[2];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input value:");
            var inputString = Console.ReadLine();
            int value = int.Parse(inputString);
            Console.WriteLine($"Result of calculation is: {IterCalculation(value)}");
        }
    }
}
