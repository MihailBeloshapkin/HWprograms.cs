using System;

namespace HW1T5
{
    class Program
    {
        private static void SortRows(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
                {
                    if (matrix[0, j] > matrix[0, j + 1])
                    {
                        for (int index = 0; index < matrix.GetLength(0); index++)
                        {
                            int tmp = matrix[index, j];
                            matrix[index, j] = matrix[index, j + 1];
                            matrix[index, j + 1] = tmp;
                        }
                    }
                }
            }
        }

        private static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 3}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,] matrix = new int[3, 5] { {3, 2, 1, 5, 4}, {4, 5, 6, 9, 0}, {3, 1, 9, 7, 4 } };
            SortRows(matrix);
            DisplayMatrix(matrix);
        }
    }
}
