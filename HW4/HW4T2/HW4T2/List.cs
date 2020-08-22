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
        /// Add data to a fixed position.
        /// </summary>
        /// <param name="position">Input position.</param>
        /// <param name="newData">New data that we would like to add.</param>
        public virtual void AddToListPosition(int position, int newData)
        {
            if (position == 0)
            {
                head = new ListElement(newData, head);
                sizeOfList++;
                return;
            }

            if (position > sizeOfList || position < 0)
            {
                throw new IncorrectInputPositionException();
            }

            var current = this.head;

            for (int iter = 0; iter < position - 1; iter++)
            {
                current = current.next;
            }

            current.next = new ListElement(newData, current.next);

            this.sizeOfList++;
        }

        /// <summary>
        /// Change element by position.
        /// </summary>
        /// <param name="position">Input position</param>
        /// <param name="newData">New data instead of previous.</param>
        public virtual void ChangeElementByPosition(int position, int newData)
        {
            if (position > sizeOfList || position < 0)
            {
                throw new IncorrectInputPositionException();
            }

            var current = this.head;

            for (int iter = 0; iter < position; iter++)
            {
                current = current.next;
            }

            current.data = newData;
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
        /// Delete element by its position. 
        /// </summary>
        /// <param name="position">Input position.</param>
        public virtual void DeleteFromListPosition(int position)
        {
            if (position < 0 || position > sizeOfList)
            {
                throw new IncorrectInputPositionException();
            }

            var current = this.head;

            if (position == 0)
            {
                head = head.next;
                sizeOfList--;
                return;
            }

            for (int iter = 0; iter < position - 1; iter++)
            {
                current = current.next;
            }

            current.next = current.next.next;
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
