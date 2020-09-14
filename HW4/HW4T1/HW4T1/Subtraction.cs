using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    /// <summary>
    /// Subtraction operation.
    /// </summary>
    public class Subtraction : Operation
    {
        /// <summary>
        /// Print substraction symbol to a console.
        /// </summary>
        public override void Display()
        {
            Console.Write("- ");
            left.Display();
            right.Display();
        }

        /// <summary>
        /// Execute subtraction operation.
        /// </summary>
        /// <returns>Resulr of the operation.</returns>
        public override int Calculate()
        {
            return left.Calculate() - right.Calculate();
        }
    }
}
