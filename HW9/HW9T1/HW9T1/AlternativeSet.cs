using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace HW9T1
{
    public class AlternativeSet<T> : ISet<T>
    {
        private IComparer<T> comparer;

        /// <summary>
        /// Alternative set constructor.
        /// </summary>
        public AlternativeSet(IComparer<T> comparer)
            => this.comparer = comparer;

        /// <summary>
        /// Tree element.
        /// </summary>
        private class TreeElement
        {
            public TreeElement(T data)
            {
                this.data = data;
            }

            public T data { get; set; }
            public TreeElement Less { get; set; }
            public TreeElement More { get; set; }
            public TreeElement Prev { get; set; }

            public bool IsLeaf()
                => Less == null && More == null;
        }

        private TreeElement root;

        public int Count { get; set; } = 0;

        public bool IsReadOnly { get; set; } = false;

        /// <summary>
        /// Add data in the set.
        /// </summary>
        /// <param name="item">Input data that we would like to add.</param>
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
                    if (current.Less == null)
                    {
                        current.Less = new TreeElement(item);
                        current.Less.Prev = current;
                        this.Count++;
                        return true;
                    }
                    current = current.Less;
                }
                else if (comparer.Compare(current.data, item) < 0)
                {
                    if (current.More == null)
                    {
                        current.More = new TreeElement(item);
                        current.More.Prev = current;
                        this.Count++;
                        return true;
                    }
                    current = current.More;
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
            return this.GetElement(item) != null;
        }

        /// <summary>
        /// Copies all elements of the collection to an array. 
        /// </summary>
        public void CopyTo(T[] array, int position)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            
            if (position + this.Count >= array.Length + 1 || position < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            foreach (var element in this)
            {
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
                    current = current.More;
                }
                else if (comparer.Compare(current.data, data) > 0)
                {
                    current = current.Less;
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
                newChild.Prev = current;
            }
            if (current.More == oldChild)
            {
                current.More = newChild;
            }
            if (current.Less == oldChild)
            {
                current.Less = newChild;
            }
        }

        /// <summary>
        /// This method finds the smallest element in the right subtree.
        /// </summary>
        /// <param name="element"></param>
        private TreeElement FindTheSmallestInRightSubTree(TreeElement element)
        {
            if (element == null || element.More == null)
            {
                throw new ArgumentNullException();
            }

            var current = element.More;

            while (current.Less != null)
            {
                current = current.Less;
            }

            return current;
        }

        /// <summary>
        /// Delete element from the set.
        /// </summary>
        /// <param name="item">Input elment that we would like to delete.</param>
        public bool Remove(T item)
        {
            var element = GetElement(item);
            
            if (element == null)
            {
                return false;
            }

            if (element == root)
            {
                if (element.IsLeaf())
                {
                    this.root = null;
                    this.Count--;
                    return true;
                }
                if (element.Less != null && element.More == null)
                {
                    this.root = element.Less;
                    this.Count--;
                    return true;
                }
                if (element.More != null && element.Less == null)
                {
                    this.root = element.More;
                    this.root.Prev = null;
                    this.Count--;
                    return true;
                }
            }
            
            if (element.IsLeaf())
            {
                SetChild(element.Prev, element, null);
                Count--;
                return true;
            }
            if (element.Less != null && element.More == null)
            {
                SetChild(element.Prev, element, element.Less);
                Count--;
                return true;
            }
            if (element.More != null && element.Less == null)
            {
                SetChild(element.Prev, element, element.More);
                Count--;
                return true;
            }
            
            var buffer = FindTheSmallestInRightSubTree(element).data;
            Remove(buffer);
            element.data = buffer;
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

            if (this.SetEquals(collection))
            {
                root = null;
                return;
            }

            foreach (var element in collection)
            {
                if (element == null)
                {
                    throw new ArgumentException();
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

            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    this.Remove(element);
                }
            }
        }

        /// <summary>
        /// Check that current set is a proper subset of the input collection.
        /// </summary>
        /// <param name="collection"></param>
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
                throw new ArgumentNullException();
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

                if (current.Less != null)
                {
                    stack.Push(current.Less);
                }

                if (current.More != null)
                {
                    stack.Push(current.More);
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
