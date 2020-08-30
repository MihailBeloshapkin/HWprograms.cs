using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            public TreeElement prev { get; set; }

            public bool IsLeaf()
                => less == null && more == null;
        }

        private TreeElement root;

        public int Count { get; set; } = 0;

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
                this.Count++;
                return true;
            }

            var current = this.root;

            while (true)
            {
                if (comparer.Compare(current.data, item) > 0)
                {
                    if (current.less == null)
                    {
                        current.less = new TreeElement(item);
                        current.less.prev = current;
                        this.Count++;
                        return true;
                    }
                    current = current.less;
                }
                else if (comparer.Compare(current.data, item) < 0)
                {
                    if (current.more == null)
                    {
                        current.more = new TreeElement(item);
                        current.more.prev = current;
                        this.Count++;
                        return true;
                    }
                    current = current.more;
                }
            }
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
        /// Copies all elements of the collection to an array. 
        /// </summary>
        public void CopyTo(T[] array, int position)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            foreach (var element in this)
            {
                if (position >= array.Length || position < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                array[position] = element;
                position++;
            }
        }

        /// <summary>
        /// Get tree element from the set by data.
        /// </summary>
        /// <param name="data">Input data.</param>
        private TreeElement GetElement(T data)
        {
            var current = this.root;

            while (current != null)
            {
                if (comparer.Compare(current.data, data) < 0)
                {
                    current = current.more;
                }
                else if (comparer.Compare(current.data, data) > 0)
                {
                    current = current.less;
                }
                else
                {
                    return current;
                }
            }

            return current;
        }

        /// <summary>
        /// Set new child for current tree element.
        /// </summary>
        /// <param name="current">Current tree element.</param>
        private void SetChild(TreeElement current, TreeElement oldChild, TreeElement newChild)
        {
            if (newChild != null)
            {
                newChild.prev = current;
            }
            if (current.more == oldChild)
            {
                current.more = newChild;
            }
            if (current.less == oldChild)
            {
                current.less = newChild;
            }
        }

        /// <summary>
        /// This method finds the smallest element in the right subtree.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private TreeElement FindTheSmallestInRightSubTree(TreeElement element)
        {
            if (element == null || element.more == null)
            {
                throw new ArgumentNullException();
            }

            var current = element.more;

            while (current.less != null)
            {
                current = current.less;
            }

            return current;
        }

        /// <summary>
        /// Delete elment from the set.
        /// </summary>
        /// <param name="item">Input elment that we would like to delete.</param>
        /// <returns>True is deletion is succesful and false in the other case.</returns>
        public bool Remove(T item)
        {
            try
            {
                var element = GetElement(item);

                if (element == root)
                {
                    if (element.IsLeaf())
                    {
                        this.root = null;
                        this.Count--;
                        return true;
                    }
                    if (element.less != null && element.more == null)
                    {
                        this.root = element.less;
                        this.Count--;
                        return true;
                    }
                    if (element.more != null && element.less == null)
                    {
                        this.root = element.more;
                        this.root.prev = null;
                        this.Count--;
                        return true;
                    }
                }

                if (element.IsLeaf())
                {
                    SetChild(element.prev, element, null);
                    Count--;
                    return true;
                }
                if (element.less != null && element.more == null)
                {
                    SetChild(element.prev, element, element.less);
                    Count--;
                    return true;
                }
                if (element.more != null && element.less == null)
                {
                    SetChild(element.prev, element, element.more);
                    Count--;
                    return true;
                }

                var buffer = FindTheSmallestInRightSubTree(element).data;
                Remove(buffer);
                element.data = buffer;
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
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

        /// <summary>
        /// Check that current set is a proper subset of the input collection.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public bool IsProperSubsetOf(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in this)
            {
                if (!collection.Contains(element))
                    {
                    return false;
                }
            }

            foreach (var element in collection)
            {
                if (!this.Contains(element))
                {
                    return true;
                }
            }

            return false;
        }
        
        /// <summary>
        /// Checks that current set is a subset of the input collection. 
        /// </summary>
        public bool IsSubsetOf(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    return false;
                }
            }


            return true;
        }

        /// <summary>
        /// Check that current set is a proper superset of the input collection.
        /// </summary>
        /// <param name="collection">Input collection.</param>
        public bool IsProperSupersetOf(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArithmeticException();
            }

            foreach (var element in collection)
            {
                if (!this.Contains(element))
                {
                    return false;
                }
            }

            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check that current set is a superset of the input collection.
        /// </summary>
        /// <param name="collection">Input collection.</param>
        public bool IsSupersetOf(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in collection)
            {
                if (!this.Contains(element))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Compares current set to the input collection.
        /// </summary>
        /// <param name="collection">Input collection that we would like 
        /// to compare with the current set.</param>
        public bool SetEquals(IEnumerable<T> collection)
        {
            return this.IsSubsetOf(collection) && this.IsSupersetOf(collection);
        }

        /// <summary>
        /// Checks that current set and input collection intersect.
        /// </summary>
        /// <param name="collection">Input collection.</param>
        public bool Overlaps(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in collection)
            {
                if (this.Contains(element))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Transforms the current set so that it only contains the elements,
        /// which are either contained in the set or only in the collection.
        /// </summary>
        /// <param name="collection"></param>
        public void SymmetricExceptWith(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in collection)
            {
                if (!this.Contains(element))
                {
                    this.Add(element);
                }
                else
                {
                    this.Remove(element);
                }
            }
        }

        /// <summary>
        /// Concatinates the current set and input collection.
        /// </summary>
        public void UnionWith(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var element in collection)
            {
                if (!this.Contains(element))
                {
                    this.Add(element);
                }
            }
        }
        
        /// <summary>
        /// Get enumerator from the current set.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (this.root == null)
            {
                yield break;
            }

            var stack = new Stack<TreeElement>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                var current = stack.Pop();

                if (current.less != null)
                {
                    stack.Push(current.less);
                }

                if (current.more != null)
                {
                    stack.Push(current.more);
                }

                yield return current.data;
            }
        }

        /// <summary>
        /// Get enumerator form the current set.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
