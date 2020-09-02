using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    /// <summary>
    /// This interface contains parser tree element functions.
    /// </summary>
    public interface ITreeElement
    {
        /// <summary>
        /// Display tree element to a console.
        /// </summary>
        public void Display();

        /// <summary>
        /// Calculate tree elements.
        /// </summary>
        /// <returns>Result of the calculation.</returns>
        public int Calculate();
    }
}
