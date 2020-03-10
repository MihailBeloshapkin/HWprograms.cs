using System;

namespace HW2T3
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

            bool isCorrect = true;
            Calculator calculator = new Calculator(stack);
            Console.WriteLine(calculator.Evaluate("2 7 + 3 / 8 *", ref isCorrect));
        }
    }
}
