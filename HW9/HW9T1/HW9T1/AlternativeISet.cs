using System;
using System.Collections.Generic;
using System.Text;

namespace HW9T1
{
    public class AlternativeISet<T> : ISet<T>
    {
        private IComparer<T> comparer;

        /// <summary>
        /// Alternative set constructor.
        /// </summary>
        public AlternativeISet(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        private class TreeElement
        {
            public TreeElement(T data)
            {

            }

            public T data;
            public TreeElement less;
            public TreeElement more;
        }

        private TreeElement root;

        public int Count { get; set; }

        public bool IsReadOnly { get; set; }

        public bool Add(T item)
        {
            var current = root;

            while (current != null)
            {
                if (comparer.Compare(current.data, item) > 0)
                {
                    current = current.less;
                }
                else if (comparer.Compare(current.data, item) < 0)
                {
                    current = current.more;
                }
                else if (comparer.Compare(current.data, item) == 0)
                {
                    return false;
                }
            }

            current = new TreeElement(item);
            return true;
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        /// <summary>
        /// Delete add data from collection.
        /// </summary>
        public void Clear()
        {
            this.root = null;
            this.Count = 0;
        }

        /// <summary>
        /// Check that collection contains input data.
        /// </summary>
        /// <param name="item">Input item that we would like to check</param>
        public bool Contains(T item)
        {
            var current = root;

            while (current != null)
            {
                if (comparer.Compare(current.data, item) == 0)
                {
                    return true;
                }
                else if (comparer.Compare(current.data, item) > 0)
                {
                    current = current.less;
                }
                else if (comparer.Compare(current.data, item) < 0)
                {
                    current = current.more;
                }
            }

            return false;
        }
    }
}
