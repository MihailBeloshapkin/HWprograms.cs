using System;

namespace HW3T1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect = true; 
            Calculation.Evaluator("2 3 +", 0, ref isCorrect);
            Calculation.Evaluator("2 7 + 3 / 8 *", 1, ref isCorrect);
            Calculation.Evaluator("6 9 + 5 - 9 5 * +", 0, ref isCorrect);
            Calculation.Evaluator("6 9 + 5 - 9 5 * +", 1, ref isCorrect);  
        }
    }
}
