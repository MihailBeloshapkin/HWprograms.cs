using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    /// <summary>
    /// Multiplication operation.
    /// </summary>
    public class Multiplication : Operation
    {
        public override void Display()
        {
            Console.Write("* ");
            left.Display();
            right.Display();
        }

        /// <summary>
        /// Executes multiplication operatrion.
        /// </summary>
        /// <returns></returns>
        public override int Calculate()
        {
            return left.Calculate() * right.Calculate();
        }
    }
}
