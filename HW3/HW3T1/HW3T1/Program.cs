using System;

namespace HW3T1
{
    class Program
    {
        static void Main(string[] args)
        {
            int stackVariant = 1;

            IStack stack;

            if (stackVariant == 0)
            {
                stack = new StackList();
            }
            else if (stackVariant == 1)
            {
                stack = new StackArray();
            }
            else
            {
                return;
            }

            Calculator calculator = new Calculator(stack);
            int result;
            bool isCorrect;

            (result, isCorrect) = calculator.Evaluate("2 7 + 3 / 8 *");
            Console.WriteLine(result);
        }
    }
}
