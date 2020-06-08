using System;
using System.Collections.Generic;
using System.Text;

namespace test2
{
    /// <summary>
    /// This class releases Move-ToFront algorithm.
    /// </summary>
    public class MoveToFront
    {
        /// <summary>
        /// Get english alphabet in lower case.
        /// </summary>
        /// <returns>Array which contains english alphabet letters.</returns>
        private char[] GetAlphabet()
        {
            char[] alphabet = new char[26];
            for (int iter = 0; iter < alphabet.Length; iter++)
            {
                alphabet[iter] = (char)(iter + 97);
            }

            return alphabet;
        }

        private bool CheckThatInputIsCorrect(string input)
        {
            for (int iter = 0; iter < input.Length; iter++)
            {
                if (input[iter] < 65 || (input[iter] > 90 && input[iter] < 97) || input[iter] > 122)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Get index in char array. 
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="symbol">Symbol whose index we would like to get.</param>
        /// <returns>-1 in case if symbol in not contained into array, index in array in other case.</returns>
        private int GetIndexInArray(char[] array, char symbol)
        {
            for (int iter = 0; iter < array.Length; iter++)
            {
                if (array[iter] == symbol)
                {
                    return iter;
                }
            }

            return -1;
        }

        /// <summary>
        /// Move-To-front algotithm.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Integer array code sequence.</returns>
        public int[] MoveToFrontAlg(string input)
        {
            if (!CheckThatInputIsCorrect(input))
            {
                throw new InputContainsIncorrectSymbolsException();
            }

            string lowerInput = input.ToLower();
            char[] alphabet = GetAlphabet();
            int[] result = new int[input.Length];

            for (int iter = 0; iter < lowerInput.Length; iter++)
            {
                int indexInAlphabet = GetIndexInArray(alphabet, lowerInput[iter]);
                result[iter] = indexInAlphabet;

                var symbol = alphabet[indexInAlphabet];
                for (int j = 0; j < indexInAlphabet; j++)
                {
                    alphabet[indexInAlphabet - j] = alphabet[indexInAlphabet - j - 1];
                }
                alphabet[0] = symbol;
            }

            return result;
        }
    }
}
