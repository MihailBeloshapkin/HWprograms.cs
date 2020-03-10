using System;
using System.Collections.Generic;
using System.Text;

namespace HW2T3
{
    class StackArray : IStack
    {
        private int[] stackArray = new int[30];
        private int headIndex = 0;
        static private int sizeOfStack = 0;

        public bool IsEmpty()
        {
            return headIndex == 0;
        }

        public void Push(int newData)
        {
            if (headIndex == stackArray.Length)
            {
                ArrayExpansion();
            }

            stackArray[headIndex] = newData;
            headIndex++;
            sizeOfStack++;
        }

        public int Pop(ref bool isCorrect)
        {
            if (headIndex == 0)
            {
                isCorrect = false;
                return -1;
            }
            int deletedData = stackArray[headIndex - 1];
            headIndex--;
            sizeOfStack--;
            return deletedData;
        }

        public int Size()
        {
            return sizeOfStack;
        }

        private void ArrayExpansion()
        {
            int newMaxStackSize = stackArray.Length * 2;
            int[] newStackArray = new int[newMaxStackSize];

            for (int index = 0; index < sizeOfStack; index++)
            {
                newStackArray[index] = stackArray[index];
            }
            stackArray = newStackArray;
        }
    }
}
