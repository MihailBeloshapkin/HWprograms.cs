using System;
using System.Collections.Generic;
using System.Text;

namespace vector
{
    public class List
    {
        public class ListElement
        {
            public ListElement(int number, int count, ListElement next)
            {
                this.number = number;
                this.count = count;
                this.next = next;
            }

            public int number;

            public int count;

            public ListElement next;

            public ListElement prev;
        }

        private ListElement head;

        private ListElement tail;

        private int size = 0;

        /// <summary>
        /// Add to list back.
        /// </summary>
        /// <param name="number">New number</param>
        /// <param name="count">Count of the new number</param>
        public void Add(int number, int count)
        {
            if (size == 0)
            {
                head = new ListElement(number, count, head);
                tail = head;
                size++;
                return;
            }

            var newElement = new ListElement(number, count, head);
            head.prev = newElement;
            head = newElement;
            size++;
        }

        public void Display()
        {
            var current = tail;

            for (int jiter = 0; jiter < size; jiter++)
            {
                for (int iter = 0; iter < current.count; iter++)
                {
                    Console.Write($"{current.number}, ");
                }
                current = current.prev;
            }
        }
    }
}
