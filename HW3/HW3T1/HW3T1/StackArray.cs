using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T1
{
    public class StackArray : IStack
    {
        static private int maxSize = 30;
        private int[] stackArray = new int[maxSize];
        private int headIndex = 0;
        static private int sizeOfStack = 0;

        public bool IsEmpty()
        {
            return headIndex == 0;
        }

        public void Push(int newData)
        {
            if (headIndex == maxSize)
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
            int newMaxStackSize = maxSize * 2;
            int[] newStackArray = new int[newMaxStackSize];

            for (int index = 0; index < sizeOfStack; index++)
            {
                newStackArray[index] = stackArray[index];
            }
            stackArray = newStackArray;
            maxSize = newMaxStackSize;
        }
    }
}
