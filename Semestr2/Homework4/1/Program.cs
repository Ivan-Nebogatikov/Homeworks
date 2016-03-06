using System;
using System.IO;

namespace Problem1
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main program method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string nameOfFile = "input.txt";
            BinaryTree binaryTree = null;
            try
            {

                binaryTree = new BinaryTree(ReadFromFile(nameOfFile));
            }
            catch
            {
                Console.WriteLine("Файл не найден!");
                return;
            }
            binaryTree.Print();
            Console.WriteLine();
            try
            {
                Console.WriteLine("Вычисленное выражение: " + binaryTree.Calculate());
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Деление на  ноль!");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Странная ошибка!");
                return;
            }
        }

        private static string ReadFromFile(string namOfFile)
        {
            using (StreamReader streamReader = new StreamReader(namOfFile))
            {
                return (streamReader.ReadToEnd());
            };
        }
    }
}
