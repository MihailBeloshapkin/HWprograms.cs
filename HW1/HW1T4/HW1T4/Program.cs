using System;

namespace HW1T4
{
    class Program
    {
        private static void DisplaySpiral(int[,] matrix)
        {
            int index1 = matrix.GetLength(0) / 2;
            int index2 = matrix.GetLength(1) / 2;
            int step = 1;
            while (index1 != matrix.GetLength(0) - 1)
            {
                for (int i = 0; i < step; i++)
                {
                    Console.WriteLine(matrix[index1, index2]);
                    index1--;
                }
                for (int i = 0; i < step; i++)
                {
                    Console.WriteLine(matrix[index1, index2]);
                    index2--;
                }
                step++;
                for (int i = 0; i < step; i++)
                {
                    Console.WriteLine(matrix[index1, index2]);
                    index1++;
                }
                for (int i = 0; i < step;  i++)
                {
                    Console.WriteLine(matrix[index1, index2]);
                    index2++;
                }
                step++;
            }
            for (int i = 0; i < step; i++)
            {
                Console.WriteLine(matrix[index1, index2]);
                index1--;
            }

        }

        static void Main(string[] args)
        {
            int[,] matrix = new int[5, 5] { {13, 12, 11, 10, 25 }, 
                                            {14, 3, 2, 9, 24 }, 
                                            {15, 4, 1, 8, 23 }, 
                                            {16, 5, 6, 7, 22 }, 
                                            {17, 18, 19, 20, 21 } };
            DisplaySpiral(matrix);
        }
    }
}
