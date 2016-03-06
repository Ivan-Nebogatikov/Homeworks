using System;

namespace Problem1
{
    /// <summary>
    /// Operator in binary tree class
    /// </summary>
    class Operator : AbstractTreeElement
    {
        /// <summary>
        /// Node value
        /// </summary>
        public string Element { get; set; }

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
        public int Calculate()
        {
            switch (Element)
            {
                case "+":
                    return LeftChild.Calculate() + RightChild.Calculate();
                case "-":
                    return LeftChild.Calculate() - RightChild.Calculate();
                case "*":
                    return LeftChild.Calculate() * RightChild.Calculate();
                case "/":
                    if (RightChild.Element != "0")
                        return LeftChild.Calculate() / RightChild.Calculate();
                    else
                        throw new DivideByZeroException();
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Print node and its children
        /// </summary>
        public void Print()
        {
            Console.Write("( " + Element + ' ');
            if (LeftChild != null)
                LeftChild.Print();
            if (RightChild != null)
                RightChild.Print();
            Console.Write(") ");
        }
    }
}
