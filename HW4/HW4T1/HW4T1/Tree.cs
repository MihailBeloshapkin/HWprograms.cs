using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Text;

namespace HW4T1
{
    /// <summary>
    /// This class comtains parser tree structure and functions.
    /// </summary>
    public class Tree
    {
        ITreeElement root;

        private class TreeElement
        {
            ITreeElement treeElement;
            TreeElement left;
            TreeElement right;
            TreeElement parent;

            public TreeElement(ITreeElement newTreeElement, TreeElement left, TreeElement right, TreeElement parent)
            {
                this.treeElement = newTreeElement;
                this.left = left;
                this.right = right;
                this.parent = parent;
            }
        }

        public Tree(string input)
        {
            int index = 0;
            this.root = CreateParserTree(input, ref index);
        }

        /// <summary>
        /// Checks that symbol is an operation.
        /// </summary>
        /// <param name="symbol">Input symbol.</param>
        /// <returns>True in case is symbol is an operation and false in the other case.</returns>
        private bool IsOperation(Char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/' ;
        }

        /// <summary>
        /// This function translates substring to integer
        /// in case if substring is a number.
        /// </summary>
        /// <param name="input">Input string that contains substring.</param>
        /// <param name="index">Index in which number starts.</param>
        /// <returns></returns>
        private int TranslateToInteger(string input, ref int index)
        {
            string result = null;

            while (index < input.Length && Char.IsDigit(input[index]))
            {
                result += input[index];
                index++;
            }

            return int.Parse(result);
        }

        /// <summary>
        /// Determine the operation as an element of a parser tree.
        /// </summary>
        /// <param name="symbol">Input operation</param>
        /// <returns>Oeration</returns>
        private Operation DetermineTheOperation(char symbol)
        {
            if (symbol == '+')
            {
                return new Addition();
            }
            if (symbol == '-')
            {
                return new Subtraction();
            }
            if (symbol == '*')
            {
                return new Multiplication();
            }
            if (symbol == '/')
            {
                return new Division();
            }

            throw new UnrecognisedCharException($"Unrecognised char: {symbol}");
        }

        /// <summary>
        /// Create parser tree
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="index">Index(0 when start parsing)</param>
        /// <returns></returns>
        private ITreeElement CreateParserTree(string input, ref int index)
        {
            while (input[index] == ' ' || input[index] == ')' || input[index] == '(')
            {
                if (index == input.Length)
                {
                    return null;
                }

                index++;
            }

            if (this.IsOperation(input[index]))
            {
                var newTreeElement = DetermineTheOperation(input[index]);
                index++;
                newTreeElement.left = CreateParserTree(input, ref index);
                newTreeElement.right = CreateParserTree(input, ref index);
                return newTreeElement;
            }
            if (char.IsDigit(input[index]))
            {
                int newNumber = TranslateToInteger(input, ref index);
                return new Operand(newNumber);
            }

            throw new UnrecognisedCharException();
        }

        /// <summary>
        /// Calculate.
        /// </summary>
        /// <returns>Calculation result.</returns>
        public int Calculate()
            => root.Calculate();

        /// <summary>
        /// Display all data from parser tree to a console.
        /// </summary>
        public void Display()
            => root.Display();
    }
}
