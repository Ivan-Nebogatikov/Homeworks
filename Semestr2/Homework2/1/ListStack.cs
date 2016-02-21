using InerfaceStack;
using NamespaceList;

namespace NamespaceListStack
{

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
            return stack.GetLength() == 0;
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
