using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    class Tree
    {
        TreeElement root;

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

        private bool IsOperation(Char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/' ;
        }

        private int TranslateToInteger(string input, ref int index)
        {
            string result = null;

            while (Char.IsDigit(input[index]) && index < input.Length)
            {
                result += input[index];
                index++;
            }

            return int.Parse(result);
        }

        private Operation DetermineTheOperation(char symbol)
        {
            if (symbol == '+')
            {
                return new Addition();
            }
            if (symbol == '-')
            {
                return new Substraction();
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

        public void CreateParserTree(string input, int index = 0)
        {
            var current = root;

            while (!Char.IsDigit(input[index]) && !IsOperation(input[index]))
            {
                index++;
            }

            if (IsOperation(input[index]))
            {
                var newTreeElement = DetermineTheOperation(input[index]);
               
            }
            if (char.IsDigit(input[index]))
            {
                int newData = TranslateToInteger(input, ref index);
               
            }
        }
    }
}
