﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    public class Substraction : Operation
    {
        public override void Display()
        {
            Console.Write("-");
        }

        public override int Calculate()
        {
            return left.Calculate() - right.Calculate();
        }
    }
}
