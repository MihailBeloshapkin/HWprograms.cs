using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T1
{
    public class Calculation
    {
        static private IStack stack;

        static private int TranslateToInteger(string input, ref int index, ref bool isCorrect)
        {
            string answer = null;

            while (index < input.Length && Char.IsDigit(input[index]))
            {
                answer += input[index];
                index++;
            }

            if (answer.Length > 9)
            {
                isCorrect = false;
                return -1;
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
            else if (stackVariant == 1)
            {
                stack = new StackArray();
            }
            else
            {
                isCorrect = false;
                return -1;
            }
            
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
                        if (firstNum == 0)
                        {
                            isCorrect = false;
                            throw new ArgumentNullException("Something is wrong");
                        }
                        stack.Push(secondNum / firstNum);
                    }
                    index++;
                }

                else if (Char.IsDigit(expression[index]))
                {
                    stack.Push(TranslateToInteger(expression, ref index, ref isCorrect));
                    if (!isCorrect)
                    {
                        return -1;
                    }
                }

                else if (expression[index] != ' ')
                {
                    isCorrect = false;
                    return -1;
                }
            }

            if (stack.Size() != 1)
            {
                isCorrect = false;
                return -1;
            }

            return stack.Pop(ref isCorrect);
        }
    }
}
