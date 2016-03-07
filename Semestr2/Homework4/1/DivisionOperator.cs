using System;

namespace Problem1
{
    /// <summary>
    /// Class for division operator in binary tree
    /// </summary>
    class DivisionOperator : Operator
    {
        /// <summary>
        /// Calculate method
        /// </summary>
        /// <returns> Int value of clildren division </returns>
        public override int Calculate()
        {
            if (RightChild.Calculate() != 0)
                return LeftChild.Calculate() / RightChild.Calculate();
            else
                throw new DivideByZeroException();
        }

        /// <summary>
        /// Print node and its children
        /// </summary>
        public override void Print()
        {
            Console.Write("( / ");
            if (LeftChild != null)
                LeftChild.Print();
            if (RightChild != null)
                RightChild.Print();
            Console.Write(") ");
        }
    }
}
