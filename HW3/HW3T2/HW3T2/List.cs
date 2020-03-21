using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T2
{
    /// <summary>
    /// <list>List</list>>
    /// </summary>
    public class List
    {
        /// <summary>
        /// List element
        /// </summary>
        class ListElement
        {
            /// <summary>
            /// Create new list element.
            /// </summary>
            /// <param name="newData">New data that we woulf blike to add</param>
            /// <param name="listElement"></param>
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

        /// <summary>
        /// Add new data to list.
        /// </summary>
        /// <param name="newData">New data which we would like to add</param>
        public void Addition(string newData)
        {
            head = new ListElement(newData, head);
            sizeOfList++;
        }

        /// <summary>
        /// Delete element from list.
        /// </summary>
        /// <param name="deleteData">Data which we would like to delete</param>
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

        /// <summary>
        /// Display all data from list to console.
        /// </summary>
        public void DisplayList()
        {
            var currentElement = head;
            for (int iter = 0; iter < sizeOfList; iter++)
            {
                Console.Write($"{currentElement.data} ");
                currentElement = currentElement.next;
            }
        }

        /// <summary>
        /// Size
        /// </summary>
        /// <returns>Size of list</returns>
        public int Size()
        {
            return sizeOfList;
        }

        /// <summary>
        /// Search input data in list by position.
        /// </summary>
        /// <param name="position">Position of element in list</param>
        /// <returns>Data in case if position value is correct.</returns>
        public string GetDataByPosition(int position)
        {
            ListElement currentElement = head;
            for (int iter = 0; iter < position; iter++)
            {
                currentElement = currentElement.next;
            }

            return currentElement.data;
        }

        /// <summary>
        /// Check the inclusion of input data.
        /// </summary>
        /// <param name="data">Data which inclusion we would like ti check</param>
        /// <returns>bool value</returns>
        public bool Contains(string data)
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
