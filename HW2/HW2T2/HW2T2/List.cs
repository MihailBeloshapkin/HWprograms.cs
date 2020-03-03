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

        public void DeleteElement(string deleteData)
        {
            if (sizeOfList == 0)
            {
                return;
            }

            var currentElement = head;
            int iter = 0;

            if (deleteData == currentElement.data)
            {
                head = head.next;
                sizeOfList--;
                return;
            }

            while (iter < sizeOfList && deleteData != currentElement.next.data)
            {
                currentElement = currentElement.next;
            }
            currentElement.next = currentElement.next.next;
            sizeOfList--;

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

        public bool CheckInclusionInList(string data)
        {
            var currentElement = head;
            for (int iter = 0; iter < sizeOfList; iter++)
            {
                if (data == currentElement.data)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
