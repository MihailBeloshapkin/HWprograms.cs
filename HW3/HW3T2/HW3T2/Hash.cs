using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T2
{
    public class Hash
    {
        static private int hashTableSize;
        private List[] array;
        static private float fillCoefficent;
        static private IHashFunction HashFunction;

        /// <summary>
        /// Create hash table
        /// </summary>
        /// <param name="size">Size of table we would like to create</param>
        /// <param name="hashFunctionChoice">Choice of user</param>
        public Hash(int size, int hashFunctionChoice)
        {
            if (size < 0)
            {
                return;
            }

            hashTableSize = size;
            array = new List[hashTableSize];
            for (int iter = 0; iter < hashTableSize; iter++)
            {
                array[iter] = new List();
            }

            if (hashFunctionChoice == 0)
            {
                HashFunction = new HashFunction1();
            }
            else if (hashFunctionChoice == 1)
            {
                HashFunction = new HashFunction2();
            }
            else
            {
                Console.WriteLine("Incorrect choice");
            }
        }

        /// <summary>
        /// Expansion os hash table in case of big count of input data.
        /// </summary>
        private void Expansion()
        {
            int newHashTableSize = hashTableSize * 2;
            List[] newArray = new List[newHashTableSize];

            for (int iter = 0; iter < newHashTableSize; iter++)
            {
                newArray[iter] = new List();
            }

            for (int index = 0; index < hashTableSize; index++)
            {
                for (int iter = 0; iter < array[index].Size(); iter++)
                {
                    string data = array[index].GetDataByPosition(iter);
                    newArray[HashFunction.HashFunction(data, newHashTableSize)].Addition(data);
                }
            }

            hashTableSize = newHashTableSize;
            array = newArray;
            fillCoefficent = 0;
        }
        
        /// <summary>
        /// Add string data into hash table.
        /// </summary>
        /// <param name="newData">Input data that we would like to add</param>
        public void AddToHashTable(string newData)
        {
            if (fillCoefficent > 1.1)
            {
                Expansion();
            }
            array[HashFunction.HashFunction(newData, hashTableSize)].Addition(newData);
            fillCoefficent = CalculateFillCoefficent();
        }

        /// <summary>
        /// Delete input data from hash table
        /// </summary>
        /// <param name="deleteData">Data that we would like to delete from hash table</param>
        public bool DeleteDataFromHashTable(string deleteData)
        {
            array[HashFunction.HashFunction(deleteData, hashTableSize)].DeleteElement(deleteData);
            return Contains(deleteData);
        }

        /// <summary>
        /// Check inclusion of input data. 
        /// </summary>
        /// <param name="data">Data that we would like to check</param>
        /// <returns></returns>
        public bool Contains(string data)
        {
            return array[HashFunction.HashFunction(data, hashTableSize)].Contains(data);
        }

        /// <summary>
        /// This function displays all data from hash table to console.
        /// </summary>
        public void DisplayHashTable()
        {
            for (int iter = 0; iter < hashTableSize; iter++)
            {
                Console.Write($"{iter} :");
                array[iter].DisplayList();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Recalculate fill coefficent in case of addition/deletion
        /// </summary>
        /// <returns>new fill coefficent</returns>
        private float CalculateFillCoefficent()
        {
            int numberOfElements = 0;

            for (int iter = 0; iter < hashTableSize; iter++)
            {
                numberOfElements += this.array[iter].Size();
            }

            return (float)numberOfElements / hashTableSize;
        }
    }
}

