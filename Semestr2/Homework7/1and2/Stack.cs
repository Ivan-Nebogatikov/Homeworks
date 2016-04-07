namespace Problem1and2
{
    /// <summary>   
    /// Class for list stack realization
    /// </summary>
    public class ListStack<T>
    {
        private List<T> stack;

        /// <summary>
        /// Create new list stack
        /// </summary>
        public ListStack()
        {
            stack = new List<T>();
        }

        /// <summary>
        /// Check is stack empty
        /// </summary>
        /// <returns> True is stack is empty </returns>
        public bool IsEmpty() => stack.GetLength() == 0;

        /// <summary>
        /// Get last stack element
        /// </summary>
        /// <returns> Last stack element; Throw EmptyStackException() if stack is empty </returns>
        public T Pop()
        {
            if (IsEmpty())
                throw new EmptyStackException();
            var temp = stack.GetElement(0); 
            stack.Remove(temp);
            return temp;
        }

        /// <summary>
        /// Add new element to stack
        /// </summary>
        /// <param name="newNumber"> Value of new element </param>
        public void Push(T newNumber)
        {
            stack.Add(newNumber);
        }
    }
}