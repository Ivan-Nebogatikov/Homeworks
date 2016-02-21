using System;

namespace Problem4
{
    // Main program class
    class Program
    {
        const int size = 7;

        // Main method for program
        static void Main(string[] args)
        {
            int[,] array = new int[size, size]
            {
               {1,2,3,5,6,8,9},
               {44,85,76,44,66,76,86},
               {73,18,19,20,21,22,23},
               {1,2,3,5,6,8,9 },
               {44,85,76,44,66,76,86},
               {73,18,19,20,21,22,23},
               {44,85,76,44,66,76,86}
            };
            SpiralPrintFromCenter(array);
        }

        static private void SpiralPrintFromCenter(int[,] array)
        {
            int i = array.GetLength(0) / 2;
            int j = array.GetLength(0) / 2;
            Console.Write("{0} ", array[i, j]);
            for (int step = 1; step <= array.GetLength(0) / 2; ++step)
            {
                ++j;
                for (int k = 1; k <= step * 2 - 1; ++k)
                {
                    Console.Write("{0} ", array[i, j]);
                    ++i;
                }
                for (int k = 1; k <= step * 2; ++k)
                {
                    Console.Write("{0} ", array[i, j]);
                    --j;
                }
                for (int k = 1; k <= step * 2; ++k)
                {
                    Console.Write("{0} ", array[i, j]);
                    --i;
                }
                for (int k = 1; k <= step * 2; ++k)
                {
                    Console.Write("{0} ", array[i, j]);
                    ++j;
                }
            }
            Console.WriteLine("{0} ", array[i, j]);
        }
    }
}
/*
Test for array size = 5;
                {1,3,2,4,7},
                {5,3,4,5,6},
                {8,10,33,45,5},
                {43,0,3,2,4},
                {4,4,5,6,7},
*/
