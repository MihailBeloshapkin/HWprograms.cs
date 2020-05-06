using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    public abstract class Operation : ITreeElement
    {
        public ITreeElement left;
        public ITreeElement right;

        public ITreeElement GetLeft()
            => left;

        public ITreeElement GetRight()
            => right;

        public void SetLeft(ITreeElement left)
        {
            this.left = left;
        }

        public void SetRight(ITreeElement right)
        {
            this.right = right;
        }


        /// <summary>
        /// Display data to a console.
        /// </summary>
        abstract public void Display();

        /// <summary>
        /// Calculate value.
        /// </summary>
        /// <returns>integer value.</returns>
        abstract public int Calculate();
    }
}
