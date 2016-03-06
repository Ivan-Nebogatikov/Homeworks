namespace Problem1
{
    /// <summary>
    /// Interface for different tree elements
    /// </summary>
    interface AbstractTreeElement
    {
        /// <summary>
        /// Value of tree element
        /// </summary>
        string Element { get; set; }

        /// <summary>
        /// Left child of element
        /// </summary>
        AbstractTreeElement LeftChild { get; set; }

        /// <summary>
        /// Right child of element
        /// </summary>
        AbstractTreeElement RightChild { get; set; }

        /// <summary>
        /// Method for element calculating
        /// </summary>
        /// <returns></returns>
        int Calculate();

        /// <summary>
        /// Method for element print
        /// </summary>
        void Print();
    }
}
