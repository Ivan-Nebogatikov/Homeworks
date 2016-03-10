using System;

namespace Problem1
{
    /// <summary>
    /// Operator in binary tree class
    /// </summary>
    public class Operator : AbstractTreeElement
    {
        /// <summary>
        /// Left child of node
        /// </summary>
        public AbstractTreeElement LeftChild { get; set; }

        /// <summary>
        /// Right child of node
        /// </summary>
        public AbstractTreeElement RightChild { get; set; }

        /// <summary>
        /// Calculating children
        /// </summary>
        /// <returns> Value of calculating expression </returns>
        public virtual int Calculate()
        {
            throw new Exception();
        }

        /// <summary>
        /// Print node and its children
        /// </summary>
        public virtual void Print()
        {
            throw new Exception();
        }
    }
}
