using System;
using System.Collections.Generic;
using System.Text;

namespace HW2T3
{
    class evaluator
    {
        static private IStack stack;

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

        static public int Evaluator(string expression, int stackVariant, ref bool isCorrect)
        {
            
            if (stackVariant == 0)
            {
                stack = new StackList();
            }
            if (stackVariant == 1)
            {
                stack = new StackArray();
            }
            
            for (int index = 0; index < expression.Length; index++)
            {                
                if (IsOperation(expression[index]))
                {
                    if (stack.Size() < 2)
                    {
                        isCorrect = false;
                        return -1;
                    }

                    int firstNum = stack.Pop();
                    int secondNum = stack.Pop();

                    if (expression[index] == '+')
                    {
                        stack.Push(firstNum + secondNum);                        
                    }

                    if (expression[index] == '-')
                    {
                        stack.Push(firstNum - secondNum);
                    }

                    if (expression[index] == '*')
                    {
                        stack.Push(firstNum * secondNum);
                    }

                    if (expression[index] == '/')
                    {
                        stack.Push(firstNum / secondNum);
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

            return stack.Pop();
        }
    }
}
