using InerfaceStack;
using NamespaceList;

namespace NamespaceStack
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
            pointer = 0;
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

    /// <summary>
    /// Class for list stack realization
    /// </summary>
    class ListStack : IStack
    {
        private List stack;

        /// <summary>
        /// Create new list stack
        /// </summary>
        public ListStack()
        {
            stack = new List();
        }

        /// <summary>
        /// Check is stack empty
        /// </summary>
        /// <returns> True is stack is empty </returns>
        public bool IsEmpty()
        {
            return stack.GetLenght() == 0;
        }

        /// <summary>
        /// Get last stack element
        /// </summary>
        /// <returns> Last stack element </returns>
        public int Pop()
        {
            int temp = stack.GetElement(0);
            stack.Remove(temp);
            return temp;
        }

        /// <summary>
        /// Add new element to stack
        /// </summary>
        /// <param name="newNumber"> Value of new element </param>
        public void Push(int newNumber)
        {
            stack.Add(newNumber);
        }
    }
}
