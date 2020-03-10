using System;
using System.Collections.Generic;
using System.Text;

namespace HW2T3
{
    interface IStack
    {
        bool IsEmpty();

        void Push(int newData);

        int Pop(ref bool isCorrect);

        int Size();
    }
}
