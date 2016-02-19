using System;

namespace Problem2
{
    // Class for calculating fibonacci number
    class Program
    {
        // Main method for calculating
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            long number = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("{0}-е  число Фибоначчи: {1}", number, Fibonacci(number));
        }

        static private long Fibonacci(long number)
        {
            long curNum = 1;
            long preNum = 1;
            for (long i = 3; i <= number; ++i)
            {
                curNum += preNum;
                preNum -= curNum;
                preNum = -preNum;
            }
            return curNum;
        }
    }
}
