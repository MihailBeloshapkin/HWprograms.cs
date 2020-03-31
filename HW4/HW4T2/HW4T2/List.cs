using System;
using System.Collections.Generic;
using System.Text;


namespace HW4T2
{
    public class List
    {
        protected ListElement head;
        protected int sizeOfList;

        protected class ListElement
        {
            public int data;
            public ListElement next;

            public ListElement(int newData, ListElement listElement)
            {
                this.data = newData;
                this.next = listElement;
            }
        }

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
            this.sizeOfList++;
        }

        /// <summary>
        /// Add new data to the back of the list.
        /// </summary>
        /// <param name="newData">Data that we want to add</param>
        public virtual void AddToListBack(int newData)
        {
            var current = head;
            ListElement newElement = new ListElement(newData, null);

            if (sizeOfList == 0)
            {
                head = newElement;
                sizeOfList++;
                return;
            }

            for (int iter = 0; iter < sizeOfList - 1; iter++)
            {
                current = current.next;
            }

            current.next = newElement;
            sizeOfList++;
        }

        /// <summary>
        /// Delete data from list front.
        /// </summary>
        /// <returns>Deleted element</returns>
        public virtual int DeleteFromListFront()
        {
            if (this.sizeOfList < 1)
            {
                throw new Exception();
            }
            int deleteData = this.head.data;
            this.head = this.head.next;
            this.sizeOfList--;
            return deleteData;
        }

        /// <summary>
        /// Delete from list back.
        /// </summary>
        /// <returns>Deleted element in case if it was possible to delete</returns>
        public virtual int DeleteFromListBack()
        {
            if (sizeOfList < 1)
            {
                throw new DeleteFromEmptyListException();
            }

            int deletedData = 0;

            if (sizeOfList == 1)
            {
                deletedData = head.data;
                head = null;
                sizeOfList--;
                return deletedData;
            }
            var current = head;

            for (int iter = 0; iter < sizeOfList - 2; iter++)
            {
                current = current.next;
            }

            deletedData = current.next.data;
            current.next = null;
            sizeOfList--;
            return deletedData;
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
    }
}
