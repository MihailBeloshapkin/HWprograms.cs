using System;
using System.Collections.Generic;
using System.Text;

namespace vector
{
    class Vector
    {
        public Vector()
        {
            this.vector = new List();
        }

        private List vector;

        public void SaveList(int[] inputArray)
        {
            int iter = 0;

            while (iter < inputArray.Length)
            {
                if (inputArray[iter] == 0)
                {
                    int zeroCounter = 1;

                    while (iter < inputArray.Length && inputArray[iter + 1] == 0)
                    {
                        zeroCounter++;
                        iter++;
                    }

                    vector.Add(0, zeroCounter);
                    iter++;
                }
                else
                {
                    vector.Add(inputArray[iter], 1);
                    iter++;
                }
            }
        }

        public void Display()
        {
            vector.Display();
        }
    }
}
