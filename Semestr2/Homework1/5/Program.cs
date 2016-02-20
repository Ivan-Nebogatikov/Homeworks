using System;

namespace Problem5
{
    // Class for sorting matrix
    class Program
    {
        const int sizeX = 5;
        const int sizeY = 6;
        const int maxNumber = 100;

        // Main method for calculating
        static void Main(string[] args)
        {
            int[,] matrix = new int[sizeX, sizeY];
            Inicialization(matrix);
            Console.WriteLine("Начальная матрица: ");
            PrintMatrix(matrix);
            MatrixSort(matrix);
            Console.WriteLine("Отсортированная по первым элементам матрица: ");
            PrintMatrix(matrix);
        }

        static private void Inicialization(int[,] matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < sizeX; ++i)
            {
                for (int j = 0; j < sizeY; ++j)
                {
                    matrix[i, j] = rand.Next(maxNumber);
                }
            }
        }

        static private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static private void MatrixSort(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); ++i)
            {
                for (int j = matrix.GetLength(1) - 1; j > i; --j)
                {
                    if (matrix[0, i] > matrix[0, j])
                    {
                        for (int k = 0; k < matrix.GetLength(0); ++k)
                            Swap(ref matrix[k, i], ref matrix[k, j]);
                    }
                }
            }
        }

        public static void Swap(ref int a, ref int b)
        {
            int c;
            c = a;
            a = b;
            b = c;
        }
    }
}
