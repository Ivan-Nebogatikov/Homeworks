using System;
using NamespaceHashTable;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable();
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("1 - добавить значение в таблицу");
                Console.WriteLine("2 - удалить значение из таблицы");
                Console.WriteLine("3 - проверить существование");
                Console.WriteLine("Другое - выход");
                Console.Write("Ваш выбор: ");
                int number = Convert.ToInt32(Console.ReadLine());
                switch(number)
                {
                    case 1:
                        Add(hashTable);
                        break;
                    case 2:
                        Delete(hashTable);
                        break;
                    case 3:
                        Check(hashTable);
                        break;
                    default:
                        cont = false;
                        break;
                }
            }
        }

        private static void Add(HashTable hashTable)
        {
            Console.Write("Введите строку: ");
            string newString = Console.ReadLine();
            hashTable.Add(newString);
            Console.WriteLine("Элемент добавлен!");
        }

        private static void Delete(HashTable hashTable)
        {
            Console.Write("Введите строку: ");
            string newString = Console.ReadLine();
            if (hashTable.Delete(newString))
                Console.WriteLine("Данный элемент удален!");
            else
                Console.WriteLine("Данного элемента не существует!");
        }

        private static void Check(HashTable hashTable)
        {
            Console.Write("Введите строку: ");
            string newString = Console.ReadLine();
            if (hashTable.Exist(newString))
                Console.WriteLine("Данный элемент существует!");
            else
                Console.WriteLine("Данного элемента не существует!");
        }
    }
}
