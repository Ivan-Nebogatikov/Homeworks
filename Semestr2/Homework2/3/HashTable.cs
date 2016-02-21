using NamespaceList;

namespace NamespaceHashTable
{
    /// <summary>
    /// Class for work with Hash Table
    /// </summary>
    class HashTable
    {
        private const int maxHash = 255;
        private List[] hashTable;
        /// <summary>
        /// Create new hash table
        /// </summary>
        public HashTable()
        {
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
            hashTable[hashFunction(newElement)].Add(newElement);
        }

        /// <summary>
        /// Delete element from hash table
        /// </summary>
        /// <param name="element"> String to deleting </param>
        /// <returns> True if element deleted else false </returns>
        public bool Delete(string element)
        {
            return hashTable[hashFunction(element)].Remove(element);
        }

        /// <summary>
        /// Check is element exist in hash table
        /// </summary>
        /// <param name="element"> Element to checking </param>
        /// <returns> True if exist else false </returns>
        public bool Exist(string element)
        {
            return hashTable[hashFunction(element)].IndexOf(element) >= 0;
        }

        private int hashFunction(string elementToHash)
        {
            int hash = 0;
            if (elementToHash.Length >= 3)
                hash = (elementToHash[0] + elementToHash[1] + elementToHash[2]) / 3;
            else
                hash = elementToHash[0];
            return hash % maxHash;
        }
    }
}
