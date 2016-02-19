using System;

namespace Problem3
{
    // Class for sorting array
    class Program
    {
        const int amountOfNumber = 5;

        // Main method for program
        static void Main(string[] args)
        {
            int[] array = new int[amountOfNumber] { 1, 2, 0, 3, -3 };
            SortArray(array);
            foreach (int element in array)
            {
                Console.Write("{0} ", element);
            }
            Console.WriteLine();
        }

        static private void SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = array.Length - 1; j > i; --j)
                {
                    if (array[i] > array[j])
                        Swap(ref array[i], ref array[j]);
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
