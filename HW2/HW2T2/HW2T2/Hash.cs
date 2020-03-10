using System;
using System.Collections.Generic;
using System.Text;

namespace HW2T2
{
    class Hash
    {
        private List[] array;
        static private float fillCoef;

        public Hash(int size)
        {
            if (size < 0)
            {
                return;
            }

            array = new List [size];
            for (int iter = 0; iter < array.Length; iter++)
            {
                array[iter] = new List();
            }
        }

        private int HashFunction(string value, int size)
        {
            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                result = (result + value[i]) % size;
            }
            return result;
        }

        private void Expansion()
        {
            int newHashTableSize = array.Length * 2;
            List[] newArray = new List [newHashTableSize];

            for (int iter = 0; iter < newHashTableSize; iter++)
            {
                newArray[iter] = new List();
            }

            for (int index = 0; index < array.Length; index++)
            {
                for (int iter = 0; iter < array[index].Size(); iter++)
                {
                    string data = array[index].GetDataByPosition(iter);
                    newArray[HashFunction(data, newHashTableSize)].Addition(data);
                }
            }

            array = newArray;
            fillCoef = CalculateFillCoeff();
        }

        public void AddToHashTable(string newData)
        {
            if (fillCoef > 1.1)
            {
                Expansion();
            }
            array[HashFunction(newData, array.Length)].Addition(newData);
            fillCoef = CalculateFillCoeff();
        }

        public void DeleteDataFromHashTable(string deleteData)
        {
            array[HashFunction(deleteData, array.Length)].DeleteElement(deleteData);
        }

        public bool CheckInclusionInHash(string data)
        {
            return array[HashFunction(data, array.Length)].CheckInclusionInList(data);
        }

        public void DisplayHashTable()
        {
            for (int iter = 0; iter < array.Length; iter++)
            {
                Console.Write($"{iter} :");
                array[iter].DisplayList();
                Console.WriteLine();
            }
        }

        private float CalculateFillCoeff()
        {
            int numberOfElements = 0;

            for (int iter = 0; iter < array.Length; iter++)
            {
                numberOfElements += array[iter].Size();
            }
            return (float)numberOfElements / array.Length;
        }
    }
}
