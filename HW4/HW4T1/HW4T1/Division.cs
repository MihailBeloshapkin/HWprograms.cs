using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    /// <summary>
    /// Division operation.
    /// </summary>
    public class Division : Operation
    {
        /// <summary>
        /// Display operation to a console.
        /// </summary>
        public override void Display()
        {
            Console.Write("/ ");
            left.Display();
            right.Display();
        }

        /// <summary>
        /// Execute division operation.
        /// </summary>
        /// <returns></returns>
        public override int Calculate()
        {
            return left.Calculate() / right.Calculate();
        }
    }
}
