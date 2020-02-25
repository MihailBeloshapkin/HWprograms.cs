using System;
using System.Collections.Generic;
using System.Text;

namespace HW2T2
{
    class List
    {
        class ListElement
        {
            public ListElement(string newData, ListElement listElement)
            {
                this.data = newData;
                this.next = listElement;
            }
            public string data;
            public ListElement next;
        }

        private ListElement head;
        private int sizeOfList;

        public void Addition(string newData)
        {
            head = new ListElement(newData, head);
            sizeOfList++;
        }

        public void DisplayList()
        {
            var currentElement = head;
            for (int iter = 0; iter < sizeOfList; iter++)
            {
                Console.Write($"{currentElement.data} ");
                currentElement = currentElement.next;
            }
        }

        public int size()
        {
            return sizeOfList;
        }

        public string GetDataByPosition(int position)
        {
            ListElement currentElement = head;
            for (int iter = 0; iter < position; iter++)
            {
                currentElement = currentElement.next;
            }

            return currentElement.data;
        }
    }
}
