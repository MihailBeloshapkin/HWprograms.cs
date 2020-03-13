using System;

namespace HW3T1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect = true; 
            int answer1 = Calculation.Evaluator("2 3 +", 0, ref isCorrect);
            int answer2 = Calculation.Evaluator("2 7 + 3 / 8 *", 1, ref isCorrect);
            int answer3 = Calculation.Evaluator("6 9 + 5 - 9 5 * +", 0, ref isCorrect);
            int answer4 = Calculation.Evaluator("6 9 + 5 - 9 5 * +", 1, ref isCorrect);  
        }
    }
}
