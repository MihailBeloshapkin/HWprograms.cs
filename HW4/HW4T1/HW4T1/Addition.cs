using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    /// <summary>
    /// Addition operation.
    /// </summary>
    public class Addition : Operation
    {
        /// <summary>
        /// Display operation to a console.
        /// </summary>
        public override void Display()
        {
            Console.Write("+ ");
            left.Display();
            right.Display();
        }

        /// <summary>
        /// Executes addition operation. 
        /// </summary>
        /// <returns></returns>
        public override int  Calculate()
        {
            return left.Calculate() + right.Calculate();
        }
    }
}
