namespace Problem2
{
    /// <summary>
    /// Class for work with Hash Table
    /// </summary>
    public class HashTable
    {
        private int maxHash;
        private List[] hashTable;
        private AbstractHashFunction hashFunction;
        /// <summary>
        /// Create new hash table
        /// </summary>
        public HashTable(int size, AbstractHashFunction function)
        {
            hashFunction = function;
            maxHash = size;
            hashTable = new List[maxHash];
            for (int i = 0; i < maxHash; ++i)
                hashTable[i] = new List();
        }

        /// <summary>
        /// Push new element to hash table
        /// </summary>
        /// <param name="newElement"> String to pushing </param>
        public void Add(string newElement)
        {
            hashTable[hashFunction.Hash(newElement, maxHash)].Add(newElement);
        }

        /// <summary>
        /// Delete element from hash table
        /// </summary>
        /// <param name="element"> String to deleting </param>
        /// <returns> True if element deleted else false </returns>
        public bool Delete(string element)
        {
            return hashTable[hashFunction.Hash(element, maxHash)].Remove(element);
        }

        /// <summary>
        /// Check is element exist in hash table
        /// </summary>
        /// <param name="element"> Element to checking </param>
        /// <returns> True if exist else false </returns>
        public bool Exist(string element)
        {
            return hashTable[hashFunction.Hash(element, maxHash)].IndexOf(element) >= 0;
        }
    }
}
