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

        public int GetOperand()
            => number;

        public void Display()
        {
            Console.Write($"{number} ");
        }

        public int Calculate()
            => number;
    }
}
