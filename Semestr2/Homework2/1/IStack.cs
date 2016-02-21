namespace InerfaceStack
{
    /// <summary>
    /// Interface for work with Stack
    /// </summary>
    interface IStack
    {
        /// <summary>
        /// Add new element to stack
        /// </summary>
        /// <param name="newNumber"> Value of new element </param>
        void Push(int newNumber);

        /// <summary>
        /// Get last stack element
        /// </summary>
        /// <returns> Last stack element </returns>
        int Pop();

        /// <summary>
        /// Check is stack empty
        /// </summary>
        /// <returns> True is stack is empty </returns>
        bool IsEmpty();
    }
}
