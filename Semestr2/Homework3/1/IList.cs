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
        /// <param name="newElement"> New Element to list </param>
        void Add(int newElement);

        /// <summary>
        /// Returns first index of element in list
        /// </summary>
        /// <param name="element"> Element value </param>
        /// <returns> >=0 if element exist; "-1" if not found </returns>
        int IndexOf(int element);

        /// <summary>
        /// Remove element from list
        /// </summary>
        /// <param name="element"> Element value to remove </param>
        /// <returns> True is removing succeeded else returns false </returns>
        bool Remove(int element);

        /// <summary>
        /// Returns list size
        /// </summary>
        /// <returns> Size </returns>
        int GetLength();

        /// <summary>
        /// Returns element in list. Numeration from 0
        /// </summary>
        /// <param name="index"> Index of element </param>
        /// <returns> Int value or Int32.MinValue if index is bigger than list size </returns>
        int GetElement(int index);
    }
}