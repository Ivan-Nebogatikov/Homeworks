using InerfaceStack;

namespace NamespaceArrayStack
{
    /// <summary>
    /// Class for Array Stack realization
    /// </summary>
    class ArrayStack : IStack
    {
        private const int maxN = 100;
        private int pointer;
        private int[] array;

        /// <summary>
        /// Create new array stack
        /// </summary>
        public ArrayStack()
        {
            array = new int[maxN];
        }

        /// <summary>
        /// Check is stack empty
        /// </summary>
        /// <returns> True is stack is empty </returns>
        public bool IsEmpty()
        {
            return pointer == 0;
        }

        /// <summary>
        /// Get last stack element
        /// </summary>
        /// <returns> Last stack element </returns>
        public int Pop()
        {
            return array[pointer--];
        }

        /// <summary>
        /// Add new element to stack
        /// </summary>
        /// <param name="newNumber"> Value of new element </param>
        public void Push(int newNumber)
        {
            ++pointer;
            array[pointer] = newNumber;
        }
    }
}
