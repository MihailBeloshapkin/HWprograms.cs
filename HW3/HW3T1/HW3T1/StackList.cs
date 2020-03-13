using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T1
{
    public class StackList : IStack
    {
        class StackElement
        {
            public StackElement(int newData, StackElement stackElement)
            {
                this.data = newData;
                this.next = stackElement;
            }

            public int data = 0;
            public StackElement next;

            
        }

        StackElement head;

        int sizeOfStack = 0;

        public void Push(int newData)
        {
            head = new StackElement(newData, head);
            sizeOfStack++;
        }

        public int Pop(ref bool isCorrect)
        {
            if (sizeOfStack == 0)
            {
                isCorrect = false;
                return -1;
            }
            int deletedData = head.data;
            head = head.next;
            sizeOfStack--;
            return deletedData;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public int Size()
        {
            return sizeOfStack;
        }
    }
}
