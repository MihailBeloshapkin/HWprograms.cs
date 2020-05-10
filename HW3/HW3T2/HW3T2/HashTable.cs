using System;
using System.Collections.Generic;
using System.Text;

namespace HW3T2
{
    /// <summary>
    /// This class contains hash table and hash table functions.
    /// </summary>
    public class HashTable
    {
        private List[] array;
        private float fillCoefficent;
        private IHashFunction hashFunction;

        /// <summary>
        /// Create hash table
        /// </summary>
        /// <param name="size">Size of table we would like to create</param>
        public HashTable(IHashFunction HashFunction)
        {
            this.hashFunction = HashFunction;
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
        /// Expansion of hash table in case of big count of input data.
        /// </summary>
        private void Expand()
        {
            var newArray = new List[array.Length * 2];

            for (int iter = 0; iter < newArray.Length; iter++)
            {
                newArray[iter] = new List();
            }

            for (int index = 0; index < array.Length; index++)
            {
                for (int iter = 0; iter < array[index].Size(); iter++)
                {
                    string data = array[index].GetDataByPosition(iter);
                    int hashIndex = TransformToTheRange(hashFunction.HashFunction(data), newArray.Length);
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
                Expand();
            }

            int hashIndex = TransformToTheRange(hashFunction.HashFunction(newData), array.Length);
            array[hashIndex].Addition(newData);
            fillCoefficent = CalculateFillCoefficent();
        }

        /// <summary>
        /// Delete input data from hash table
        /// </summary>
        /// <param name="deleteData">Data that we would like to delete from hash table</param>
        public bool DeleteDataFromHashTable(string deleteData)
        {
            int hashIndex = TransformToTheRange(hashFunction.HashFunction(deleteData), array.Length);
            array[hashIndex].DeleteElement(deleteData);
            fillCoefficent = CalculateFillCoefficent();
            return Contains(deleteData);
        }

        /// <summary>
        /// Check inclusion of input data. 
        /// </summary>
        /// <param name="data">Data that we would like to check</param>
        /// <returns></returns>
        public bool Contains(string data)
        {
            int hashIndex = TransformToTheRange(hashFunction.HashFunction(data), array.Length);
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