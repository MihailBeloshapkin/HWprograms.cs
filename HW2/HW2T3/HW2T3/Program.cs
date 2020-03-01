using System;

namespace HW2T3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect = true;
            int answer1 = evaluator.Evaluator("2 7 + 3 / 8 *", 0, ref isCorrect);
            int answer2 = evaluator.Evaluator("2 7 + 3 / 8 *", 1, ref isCorrect);

        }
    }
}
