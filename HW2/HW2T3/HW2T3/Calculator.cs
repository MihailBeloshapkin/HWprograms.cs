using System;
using System.Collections.Generic;
using System.Text;

namespace HW2T3
{
    class Calculator
    {
        public IStack stack;

        public Calculator(IStack stack)
        {
            this.stack = stack;
        }

        static private int TranslateToInteger(string input, ref int index)
        {
            string answer = null;

            while (Char.IsDigit(input[index]))
            {
                answer += input[index];
                index++;
            }

            return int.Parse(answer);
        }

        static private bool IsOperation(char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
        }

        public int Evaluate(string expression, ref bool isCorrect)
        {
            for (int index = 0; index < expression.Length; index++)
            {                
                if (IsOperation(expression[index]))
                {
                    int firstNum = stack.Pop(ref isCorrect);
                    int secondNum = stack.Pop(ref isCorrect);
                    if (!isCorrect)
                    {
                        return -1;
                    }

                    if (expression[index] == '+')
                    {
                        stack.Push(firstNum + secondNum);                        
                    }

                    if (expression[index] == '-')
                    {
                        stack.Push(secondNum - firstNum);
                    }

                    if (expression[index] == '*')
                    {
                        stack.Push(firstNum * secondNum);
                    }

                    if (expression[index] == '/')
                    {
                        stack.Push(secondNum / firstNum);
                    }
                    index++;
                }

                else if (Char.IsDigit(expression[index]))
                {
                    stack.Push(TranslateToInteger(expression, ref index));
                }
            }

            if (stack.IsEmpty())
            {
                isCorrect = false;
                return -1;
            }

            return stack.Pop(ref isCorrect);
        }
    }
}
