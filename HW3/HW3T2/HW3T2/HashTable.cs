using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T2
{
    public class HashTable
    {
        private List[] array;
        private float fillCoefficent;
        private IHashFunction HashFunction;

        /// <summary>
        /// Create hash table
        /// </summary>
        /// <param name="size">Size of table we would like to create</param>
        public HashTable(IHashFunction HashFunction)
        {
            this.HashFunction = HashFunction;
            array = new List[5];
            for (int iter = 0; iter < 5; iter++)
            {
                array[iter] = new List();
            }

        }

        /// <summary>
        /// Transform hash function returned index to the right range.
        /// </summary>
        /// <param name="hashFunctionIndex">Input index</param>
        /// <returns>Correct index</returns>
        private int TransformToTheRange(int hashFunctionIndex, int currentSize)
        {
            if (hashFunctionIndex < 0 || hashFunctionIndex >= currentSize)
            {
                hashFunctionIndex = Math.Abs(hashFunctionIndex) % currentSize;
            }

            return hashFunctionIndex;
        }

        /// <summary>
        /// Expansion os hash table in case of big count of input data.
        /// </summary>
        private void Expansion()
        {
            int newHashTableSize = array.Length * 2;
            List[] newArray = new List[newHashTableSize];

            for (int iter = 0; iter < newHashTableSize; iter++)
            {
                newArray[iter] = new List();
            }

            for (int index = 0; index < array.Length; index++)
            {
                for (int iter = 0; iter < array[index].Size(); iter++)
                {
                    string data = array[index].GetDataByPosition(iter);
                    int hashIndex = TransformToTheRange(HashFunction.HashFunction(data), newHashTableSize);
                    newArray[hashIndex].Addition(data);
                }
            }

            array = newArray;
            fillCoefficent = CalculateFillCoefficent();
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

            int hashIndex = TransformToTheRange(HashFunction.HashFunction(newData), array.Length);
            array[hashIndex].Addition(newData);
            fillCoefficent = CalculateFillCoefficent();
        }

        /// <summary>
        /// Delete input data from hash table
        /// </summary>
        /// <param name="deleteData">Data that we would like to delete from hash table</param>
        public bool DeleteDataFromHashTable(string deleteData)
        {
            int hashIndex = TransformToTheRange(HashFunction.HashFunction(deleteData), array.Length);
            array[hashIndex].DeleteElement(deleteData);
            return Contains(deleteData);
        }

        /// <summary>
        /// Check inclusion of input data. 
        /// </summary>
        /// <param name="data">Data that we would like to check</param>
        /// <returns></returns>
        public bool Contains(string data)
        {
            int hashIndex = TransformToTheRange(HashFunction.HashFunction(data), array.Length);
            return array[hashIndex].Contains(data);
        }

        /// <summary>
        /// This function displays all data from hash table to console.
        /// </summary>
        public void DisplayHashTable()
        {
            for (int iter = 0; iter < array.Length; iter++)
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

            for (int iter = 0; iter < array.Length; iter++)
            {
                numberOfElements += this.array[iter].Size();
            }

            return (float)numberOfElements / array.Length;
        }
    }
}