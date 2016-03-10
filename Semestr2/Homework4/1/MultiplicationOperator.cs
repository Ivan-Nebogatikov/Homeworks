using System;

namespace Problem1
{
    /// <summary>
    /// Class for multiplication operator in binary tree
    /// </summary>
    class MultiplicationOperator : Operator
    {
        /// <summary>
        /// Calculate method
        /// </summary>
        /// <returns> Int value of clildren multiplication </returns>
        public override int Calculate() => LeftChild.Calculate() * RightChild.Calculate();

        /// <summary>
        /// Print node and its children
        /// </summary>
        public override void Print()
        {
            Console.Write("( * ");
            if (LeftChild != null)
                LeftChild.Print();
            if (RightChild != null)
                RightChild.Print();
            Console.Write(") ");
        }
    }
}
