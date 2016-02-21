using System;
using NamespaceArrayStack;
using NamespaceListStack;
using NamespaceCalculator;

namespace NamespaceMain
{
    /// <summary>
    /// Main class for calculating
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        private static void Main(string[] args)
        {
            //var stack = new ArrayStack();
            var stack = new ListStack();
            Console.Write("Введите выражение в постфиксном виде: ");
            string str = Console.ReadLine();
            int answer = Calculator.Calculate(stack, str);
            if (answer == Int32.MinValue)
                Console.WriteLine("В выражении ошибка!");
            else
                Console.WriteLine("Ответ: {0}", answer);
        }
    }
}
