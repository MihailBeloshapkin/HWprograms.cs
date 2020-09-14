using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T1
{
    public class Calculator
    {
        public IStack stack;

        public Calculator(IStack stack)
        {
            this.stack = stack;
        }

        static private int TranslateToInteger(string input, ref int index)
        {
            string answer = null;

            while (index < input.Length && Char.IsDigit(input[index]))
            {
                answer += input[index];
                index++;
            }

            return int.Parse(answer);
        }

        static private bool IsOperation(char symbol)
            => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';

        public (int, bool) Evaluate(string expression)
        {
            bool isCorrect = true;

            for (int index = 0; index < expression.Length; index++)
            {
                if (IsOperation(expression[index]))
                {
                    int firstNum = stack.Pop(ref isCorrect);
                    int secondNum = stack.Pop(ref isCorrect);
                    
                    if (!isCorrect)
                    {
                        return (-1, isCorrect);
                    }

                    switch (expression[index])
                    {
                        case '+':
                            stack.Push(firstNum + secondNum);
                            break;
                        case '-':
                            stack.Push(secondNum - firstNum);
                            break;
                        case '*':
                            stack.Push(firstNum * secondNum);
                            break;
                        case '/':
                            if (firstNum == 0)
                            {
                                isCorrect = false;
                                return (-1, isCorrect);
                            }
                            stack.Push(secondNum / firstNum);
                            break;
                    }
                   
                    index++;
                }
                else if (Char.IsDigit(expression[index]))
                {
                    stack.Push(TranslateToInteger(expression, ref index));
                }
            }

            if (stack.Size() != 1)
            {
                isCorrect = false;
                return (-1, isCorrect);
            }

            return (stack.Pop(ref isCorrect), isCorrect);
        }
    }
}