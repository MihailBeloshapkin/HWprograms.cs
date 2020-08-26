using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

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
                this.data = data;
            }

            public T data;
            public TreeElement less { get; set; }
            public TreeElement more { get; set; }

            public bool IsLeaf()
                => less == null && more == null;
        }

        private TreeElement root;

        public int Count { get; set; }

        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Add data in the set.
        /// </summary>
        /// <param name="item">Input data that we would like to add.</param>
        /// <returns></returns>
        public bool Add(T item)
        {
            if (this.Contains(item))
            {
                return false;
            }

            if (root == null)
            {
                this.root = new TreeElement(item);
                return true;
            }

            var current = this.root;

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

        /// <summary>
        /// Fills input with collection elements.
        /// </summary>
        /// <param name="array">Input array which we would like to fill.</param>
        /// <param name="position">Current position.</param>
        /// <param name="current">Current tree element.</param>
        private void FillTheArray(T[] array, ref int position, TreeElement current)
        {
            if (current == null)
            {
                return;
            }
            FillTheArray(array, ref position, current.less);
            if (position >= array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            array[position] = current.data;
            position++;
            FillTheArray(array, ref position, current.more);
        }

        /// <summary>
        /// Copies all elements of the collection to an array. 
        /// </summary>
        public void CopyTo(T[] array, int position)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            var current = this.root;
            FillTheArray(array, ref position, current);
        }

        /// <summary>
        /// Delete elment from the set.
        /// </summary>
        /// <param name="item">Input elment that we would like to delete.</param>
        /// <returns>True is deletion is succesful and false in the other case.</returns>
        public bool Remove(T item)
        {
            TreeElement parent = null;
            var current = this.root;

            if (!Contains(item))
            {
                return false;
            }

            this.Count--;

            while (comparer.Compare(current.data, item) != 0)
            {
                parent = current;
                if (comparer.Compare(current.data, item) < 0)
                {
                    current = current.more;
                }
                else if (comparer.Compare(current.data, item) > 0)
                {
                    current = current.less;
                }
            }

            if (current.IsLeaf())
            {
                current = null;
                return true;
            }
            
            if (current.more != null) 
            {
                var elementForDeletion = current;
                current = current.more;
                
                while (current.less != null)
                {
                    current = current.less;
                }
                elementForDeletion = current;
                current = current.more;
                return true;
            }

            
            if (current.less != null)
            {
                var elementForDeletion = current;
                current = current.less;

                while (current.more != null)
                {
                    current = current.more;
                }

                elementForDeletion = current;
                current = current.less;
                return true;
            }

            return true;
        }

        /// <summary>
        /// Delete all elements of the collection from the set.
        /// </summary>
        public void ExceptWith(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in collection)
            {
                if (element == null)
                {
                    throw new ArgumentNullException();
                }

                Remove(element);
            }
        }

        /// <summary>
        /// Transforms the set so that it only contains the elements of the collection. 
        /// </summary>
        public void IntersectWith(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in collection)
            {
                if (!this.Contains(element))
                {
                    this.Remove(element);
                }
            }
        }
    }
}
