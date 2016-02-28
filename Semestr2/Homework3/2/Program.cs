using System;

namespace Problem2
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
        public static void Main(string[] args)
        {
            Console.Write("Выберите размер хэш-функции: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.Write("Выберите хэш-функцию: ");
            HashTable hashTable;
            int functionNumber = Convert.ToInt32(Console.ReadLine());
            switch (functionNumber)
            {
                case 1:
                    hashTable = new HashTable(size, new FirstHashFunction());
                    break;
                case 2:
                    hashTable = new HashTable(size, new SecondHashFunction());
                    break;
                default:
                    hashTable = new HashTable(size, new ThirdHashFunction());
                    break;
            }
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("1 - добавить значение в таблицу");
                Console.WriteLine("2 - удалить значение из таблицы");
                Console.WriteLine("3 - проверить существование");
                Console.WriteLine("Другое - выход");
                Console.Write("Ваш выбор: ");
                int number = Convert.ToInt32(Console.ReadLine());
                switch (number)
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