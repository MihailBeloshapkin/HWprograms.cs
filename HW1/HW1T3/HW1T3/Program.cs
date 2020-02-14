using System;

namespace HW1T3
{
    class Program
    {
        private static void CountSort(int[] array)
        {
            int maxNumber = array[0];
            int minNumber = array[0];

            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] > maxNumber)
                {
                    maxNumber = array[index];
                }
                if (array[index] < minNumber)
                {
                    minNumber = array[index];
                }
            }
            int[] countArray = new int[maxNumber - minNumber + 1];
            for (int index = 0; index < array.Length; index++)
            {
                countArray[array[index] - minNumber]++;
            }

            int indexOfOutputArray = 0;

            for (int index = 0; index < maxNumber - minNumber + 1; index++)
            {
                while (countArray[index] > 0)
                {
                    array[indexOfOutputArray] = index + 1;
                    indexOfOutputArray++;
                    countArray[index]--;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input size of array:");
            var input = Console.ReadLine();
            int sizeOfArray = int.Parse(input);
            if (sizeOfArray <= 0)
            {
                Console.WriteLine("Incorrect value of array size");
                return;
            }
            int[] array = new int[sizeOfArray];
            for (int index = 0; index < sizeOfArray; index++)
            {
                var inputValue = Console.ReadLine();
                array[index] = int.Parse(inputValue);
            }
            CountSort(array);
            Console.WriteLine("Sorted array:");
            for (int index = 0; index < array.Length; index++)
            {
                Console.WriteLine(array[index]);
            }
        }
    }
}
