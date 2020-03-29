using System;
using System.Collections.Generic;
using System.Text;

namespace HW4T1
{
    class Tree
    {
        TreeElement root;

        private class TreeElement
        {
            int id;
            int number;
            char operation;

            public TreeElement(int newNumber, char newOperation, int id)
            {
                this.number = newNumber;
                this.operation = newOperation;
                this.id = id;
            }
        }
        

    }
}
