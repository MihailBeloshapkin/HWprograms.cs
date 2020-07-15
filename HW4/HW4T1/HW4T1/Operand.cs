using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    class Operand : ITreeElement
    {
        private int number;

        public Operand(int newNumber)
        {
            this.number = newNumber;
        }

        /// <summary>
        /// Get current operand.
        /// </summary>
        /// <returns>Current operand.</returns>
        public int GetOperand()
            => number;

        /// <summary>
        /// Display current operand to a console.
        /// </summary>
        public void Display()
        {
            Console.Write($"{number} ");
        }

        /// <returns>Current value.</returns>
        public int Calculate()
            => number;
    }
}
