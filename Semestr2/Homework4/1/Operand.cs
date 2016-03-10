using System;

namespace Problem1
{
    /// <summary>
    /// Operand in binary tree class
    /// </summary>
    public class Operand : AbstractTreeElement
    {
        /// <summary>
        /// Operand value
        /// </summary>
        public int Element { get; set; }
     
        /// <summary>
        /// Get value of expression
        /// </summary>
        /// <returns> Int value </returns>
        public int Calculate() => Convert.ToInt32(Element);

        /// <summary>
        /// Print node element
        /// </summary>
        public void Print()
        {
            Console.Write(Element + ' ');
        }
    }
}
