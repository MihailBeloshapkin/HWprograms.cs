using System;
using System.Collections.Generic;
using System.Text;

namespace HW2T3
{
    class StackArray : IStack
    {
        private int[] stackArray = new int[100];
        private int headIndex = 0;
        static private int sizeOfStack = 0;

        public bool IsEmpty()
        {
            return headIndex == 0;
        }

        public void Push(int newData)
        {
            stackArray[headIndex] = newData;
            headIndex++;
            sizeOfStack++;
        }

        public int Pop()
        {
            int deletedData = stackArray[headIndex - 1];
            headIndex--;
            sizeOfStack--;
            return deletedData;
        }   
        
        public int Size()
        {
            return sizeOfStack;
        }
    }
}
