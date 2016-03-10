using System;

namespace Problem1
{
    /// <summary>
    /// Class for plus operator in binary tree
    /// </summary>
    class PlusOperator : Operator
    {
        /// <summary>
        /// Calculate method
        /// </summary>
        /// <returns> Int value of clildren sum </returns>
        public override int Calculate() => LeftChild.Calculate() + RightChild.Calculate();

        /// <summary>
        /// Print node and its children
        /// </summary>
        public override void Print()
        {
            Console.Write("( + ");
            if (LeftChild != null)
                LeftChild.Print();
            if (RightChild != null)
                RightChild.Print();
            Console.Write(") ");
        }
    }
}
