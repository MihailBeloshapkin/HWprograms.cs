using System;
using System.Collections.Generic;
using System.Text;

namespace HW2T1
{
    class List
    {
        class ListElement
        {
            public ListElement(int newData, ListElement listElement)
            {
                this.data = newData;
                this.next = listElement;
            }
            public int data;
            public ListElement next;
        }

        private ListElement head;

        private int sizeOfList;

        public void DisplayList()
        {
            var currentElement = head;
            for (int iter = 0; iter < sizeOfList; iter++)
            {
                Console.Write($"{currentElement.data} ");
                currentElement = currentElement.next;
            }
        }

        public int GetSize()
        {
            return sizeOfList;
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public void AddToListPosition(int position, int newData)
        {
            if (position == 0)
            {
                head = new ListElement(newData, head);
                sizeOfList++;
                return;
            }

            if (position > sizeOfList)
            {
                Console.WriteLine("Incorrect position value");
                return;
            }

            var currentElement = head;

            for (int iter = 0; iter < position - 1; iter++)
            {
                currentElement = currentElement.next;
            }
            
            currentElement.next = new ListElement(newData, currentElement.next);
            
            sizeOfList++;
        }

        public void DeleteFromListPosition(int position)
        {
            if (position < 0 || position > sizeOfList - 1)
            {
                Console.WriteLine("Incorrect position value");
            }

            var currentElement = head;

            if (position == 0)
            {
                head = head.next;
                sizeOfList--;
                return;
            }
     
            for (int iter = 0; iter < position - 1; iter++)
            {
                currentElement = currentElement.next;
            }

            currentElement.next = currentElement.next.next;
            sizeOfList--;
        }

        public int GetDataByPosition(int position)
        {
            if (position < 0 || position > sizeOfList - 1)
            {
                Console.WriteLine("Incorrect position value");
                return -1;
            }

            var currentElement = head;

            for (int iter = 0; iter < position; iter++)
            {
                currentElement = currentElement.next;
            }

            return currentElement.data;
        }

        public void SetDataByPosition(int position, int newData)
        {
            var currentElement = head;

            for (int iter = 0; iter < position; iter++)
            {
                currentElement = currentElement.next;
            }

            currentElement.data = newData;
        }
    }
}
