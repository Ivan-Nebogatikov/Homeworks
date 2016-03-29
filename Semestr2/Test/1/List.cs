namespace Problem1
{
    /// <summary>
    /// Main list class
    /// </summary>
    public class List : IList
    {
        private Node head;
        private int size;

        private class Node
        {
            /// <summary>
            /// Create new node
            /// </summary>
            /// <param name="value"> Value of new node </param>
            public Node(int value)
            {
                Value = value;
            }

            /// <summary>
            /// Set and get node value
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// Get and set next node
            /// </summary>
            public Node Next { get; set; }
        }

        /// <summary>
        /// List constructor
        /// </summary>
        public List()
        {
        }

        /// <summary>
        /// Add new elemet to list
        /// </summary>
        /// <param name="newElement"> New element to list </param>
        public virtual void Add(int newElement)
        {
            var newNode = new Node(newElement);
            if (size == 0)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            ++size;
        }

        /// <summary>
        /// Returns first index of element in list
        /// </summary>
        /// <param name="element"> Element value </param>
        /// <returns> >=0 if element exist; ElementDoesNotFoundInListException() if element does not exist </returns>
        public int IndexOf(int element)
        {
            Node temp = head;
            int i = 0;
            while (temp != null)
            {
                if (temp.Value == element)
                    return i;
                temp = temp.Next;
                ++i;
            }
            throw new ElementDoesNotFoundInListException();
        }

        /// <summary>
        /// Remove element from list
        /// Throw RemoveNotExistingElementException() if element does not exist
        /// </summary>
        /// <param name="position"> Element index to remove </param>
        public void Remove(int position)
        {
            if (head == null)
                throw new RemoveNotExistingElementException();
            if (position >= size || position < 0)
                throw new OutOfBoundsOfListException();
            if (position == 0)
            {
                head = head.Next;
                --size;
                return;
            }
            var temp = head;
            var secondTemp = head;
            for (int i = 1; i <= position; ++i)
            {
                secondTemp = temp;
                temp = temp.Next;
            }
            secondTemp.Next = temp.Next;
            --size;
        }

        /// <summary>
        /// Returns list size
        /// </summary>
        /// <returns> Size </returns>
        public int GetLength()
        {
            return size;
        }

        /// <summary>
        /// Returns element in list. Numeration from 0
        /// </summary>
        /// <param name="index"> Index of element </param>
        /// <returns> Int value or OutOfBoundsOfListException() if index is bigger than list size </returns>
        public int GetElement(int index)
        {
            if (index >= size)
                throw new OutOfBoundsOfListException();
            Node temp = head;
            for (int i = 0; i < index; ++i)
            {
                temp = temp.Next;
            }
            return temp.Value;
        }
    }
}