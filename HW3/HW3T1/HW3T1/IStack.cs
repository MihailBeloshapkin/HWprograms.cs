using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T1
{
    public interface IStack
    {
        bool IsEmpty();

        void Push(int newData);

        int Pop(ref bool isCorrect);

        int Size();
    }
}
