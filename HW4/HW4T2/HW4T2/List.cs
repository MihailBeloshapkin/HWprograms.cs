using System;
using System.Collections.Generic;
using System.Text;


namespace HW4T2
{
    /// <summary>
    /// This class contains list structure.
    /// </summary>
    public class List
    {
        private ListElement head;
        private ListElement tail;

        private int sizeOfList = 0;

        private class ListElement
        {
            public int data;
            public ListElement next;

            public ListElement(int newData, ListElement listElement)
            {
                this.data = newData;
                this.next = listElement;
            }
        }

        /// <summary>
        /// Display add data from list to a console.
        /// </summary>
        public void Display()
        {
            var current = this.head;

            for (int iter = 0; iter < this.sizeOfList; iter++)
            {
                Console.Write($"{current.data}, ");
                current = current.next;
            }
        }

        /// <summary>
        /// Add new element in front of list.
        /// </summary>
        /// <param name="newData">New data that we want to add</param>
        public virtual void AddToListFront(int newData)
        {
            this.head = new ListElement(newData, this.head);

            if (sizeOfList == 0)
            {
                this.tail = this.head;
            }
            this.sizeOfList++;
        }

        /// <summary>
        /// Delete data from list front.
        /// </summary>
        /// <returns>Deleted element</returns>
        public virtual void DeleteFromListFront()
        {
            if (this.sizeOfList < 1)
            {
                throw new DeleteFromEmptyListException();
            }
            this.head = this.head.next;
            this.sizeOfList--;
        }

        /// <summary>
        /// Delete from list back.
        /// </summary>
        /// <returns>Deleted element in case if it was possible to delete</returns>
        public virtual void DeleteFromListBack()
        {
            if (sizeOfList < 1)
            {
                throw new DeleteFromEmptyListException();
            }

            this.tail = null;
            this.sizeOfList--;
        }

        /// <summary>
        /// Check that element is contained in list.
        /// </summary>
        /// <param name="data">Data that we want to check</param>
        /// <returns></returns>
        public bool Contains(int data)
        {
            var current = this.head;

            for (int iter = 0; iter < this.sizeOfList; iter++)
            {
                if (current.data == data)
                {
                    return true;
                }
                current = current.next;
            }

            return false;
        }

        /// <summary>
        /// Size of list.
        /// </summary>
        /// <returns>Size of list</returns>
        public int Size()
            => sizeOfList;
    }
}
