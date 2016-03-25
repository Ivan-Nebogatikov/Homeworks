namespace Problem1
{
    /// <summary>
    /// Interface for work with List
    /// </summary>
    interface IList
    {
        /// <summary>
        /// Add new elemet to list
        /// </summary>
        /// <param name="newElement"> New element to list </param>
        void Add(int newElement);

        /// <summary>
        /// Returns first index of element in list
        /// </summary>
        /// <param name="element"> Element value </param>
        /// <returns> >=0 if element exist; ElementDoesNotFoundInListException() if element does not exist </returns>
        int IndexOf(int element);

        /// <summary>
        /// Remove element from list
        /// Throw RemoveNotExistingElementException() if element does not exist
        /// </summary>
        /// <param name="position"> Element index to remove </param>
        void Remove(int position);

        /// <summary>
        /// Returns list size
        /// </summary>
        /// <returns> Size </returns>
        int GetLength();

        /// <summary>
        /// Returns element in list. Numeration from 0
        /// </summary>
        /// <param name="index"> Index of element </param>
        /// <returns> Int value or OutOfBoundsOfListException() if index is bigger than list size </returns>
        int GetElement(int index);
    }
}