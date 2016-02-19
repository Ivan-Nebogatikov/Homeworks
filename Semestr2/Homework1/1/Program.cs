using System;

namespace Problem1
{
    // Class for calculating factorial number
    class Program
    {
        // Main method for calculating
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            ulong number = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine("Факториал числа: {0}", Factorial(number));
        }

        private static ulong Factorial(ulong number)
        {
            if (number > 0)
                return number * Factorial(number - 1);
            return 1;
        }
    }
}
