using System;

namespace HW2T3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCorrect = true;
            int answer = evaluator.Evaluator("2 7 +", 0, ref isCorrect);
        }
    }
}
