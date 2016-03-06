using System;

namespace Problem1
{
    /// <summary>
    /// Operand in binary tree class
    /// </summary>
    class Operand : AbstractTreeElement
    {
        /// <summary>
        /// Operand value
        /// </summary>
        public string Element { get; set; }

        /// <summary>
        /// Left child of node
        /// </summary>
        public AbstractTreeElement LeftChild { get; set; }

        /// <summary>
        /// Right childe of node
        /// </summary>
        public AbstractTreeElement RightChild { get; set; }

        /// <summary>
        /// Get value of expression
        /// </summary>
        /// <returns> Int value </returns>
        public int Calculate()
        {
            return Convert.ToInt32(Element);
        }

        /// <summary>
        /// Print node element
        /// </summary>
        public void Print()
        {
            Console.Write(Element + ' ');
        }
    }
}
