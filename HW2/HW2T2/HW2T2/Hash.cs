using System;
using System.Collections.Generic;
using System.Text;

namespace HW2T2
{
    class Hash
    {
        static private int hashTableSize;
        private List[] array;
        static private float fillCoef;

        public Hash(int size)
        {
            hashTableSize = size;
            array = new List [hashTableSize];
            for (int iter = 0; iter < hashTableSize; iter++)
            {
                array[iter] = new List();
            }
        }

        private int hashFunction(string value)
        {
            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                result = (result + value[i]) % hashTableSize;
            }
            return result;
        }

        private void Expansion()
        {
            int newHashTableSize = hashTableSize * 2;
            List[] newArray = new List [newHashTableSize];

            for (int iter = 0; iter < newHashTableSize; iter++)
            {
                newArray[iter] = new List();
            }

            for (int index = 0; index < hashTableSize; index++)
            {
                for (int iter = 0; iter < array[index].size(); iter++)
                {
                    string data = array[index].GetDataByPosition(iter);
                    newArray[hashFunction(data)].Addition(data);
                }
            }

            hashTableSize = newHashTableSize;
            array = newArray;
            fillCoef = 0;
        }

        public void AddToHashTable(string newData)
        {
            if (fillCoef > 1.1)
            {
                Expansion();
            }
            array[hashFunction(newData)].Addition(newData);
            fillCoef = CalculateFillCoeff();
        }

        public void DisplayHashTable()
        {
            for (int iter = 0; iter < hashTableSize; iter++)
            {
                Console.Write($"{iter} :");
                array[iter].DisplayList();
                Console.WriteLine();
            }
        }

        private float CalculateFillCoeff()
        {
            int numberOfElements = 0;

            for (int iter = 0; iter < hashTableSize; iter++)
            {
                numberOfElements += array[iter].size();
            }
            return (float)numberOfElements / hashTableSize;
        }
    }
}
