using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Problem1
{
    /// <summary>
    /// Main program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main progtam method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Dictionary");
            var collection = database.GetCollection<Note>("Note");
            while (true)
            {
                Console.WriteLine("0 - выйти");
                Console.WriteLine("1 - добавить запись");
                Console.WriteLine("2 - найти телефон по имени ");
                Console.WriteLine("3 - найти имя по телефону ");
                Console.Write("Ввод: ");
                int number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 0:
                        return;
                    case 1:
                        AddNewNote(collection);
                        break;
                    case 2:
                        FindByName(collection);
                        break;
                    case 3:
                        FindByNumber(collection);
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод");
                        break;
                }
            }
        }

        private static void AddNewNote(IMongoCollection<Note> collection)
        {
            Console.Write("Введите номер: ");
            string newNumber = Console.ReadLine();
            Console.Write("Введите имя: ");
            string newName = Console.ReadLine();
            var list = collection.Find(new BsonDocument()).ToList();
            foreach (var node in list)
                if (node.Number == newNumber)
                {
                    Console.WriteLine("Такой номер уже записан под именем " + node.Name);
                    return;
                }
            collection.InsertOne(new Note { Name = newName, Number = newNumber });
            Console.WriteLine("Запись добавлена");
        }

        private static void FindByNumber(IMongoCollection<Note> collection)
        {
            Console.Write("Введите номер для поиска: ");
            string number = Console.ReadLine();
            var list = collection.Find(new BsonDocument()).ToList();
            foreach (var node in list)
                if (node.Number == number)
                {
                    Console.WriteLine("Его имя: {0}", node.Name);
                    return;
                }
            Console.WriteLine("Ничего не найдено");
        }

        private static void FindByName(IMongoCollection<Note> collection)
        {
            Console.Write("Введите имя для поиска: ");
            string name = Console.ReadLine();
            var list = collection.Find(new BsonDocument()).ToList();
            int count = 0;
            foreach (var node in list)
                if (node.Name == name)
                {
                    ++count;
                    Console.WriteLine("Его номер ({0}): {1}", count, node.Number);
                }
            if (count == 0)
                Console.WriteLine("Ничего не найдено");
        }
    }
}
