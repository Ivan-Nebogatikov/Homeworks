using System;

namespace Homework1
{
    /// <summary>
    /// Main program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main program method
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(6);
            tree.Print();
            tree.Delete(6);
            tree.Print();
            Console.WriteLine(tree.Contains(6));
        }
    }
}
