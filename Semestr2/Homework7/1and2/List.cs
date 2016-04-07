using System.Collections;

namespace Problem1and2
{
    /// <summary>
    /// Main list class
    /// </summary>
    public class List<T> : IEnumerable
    {
        private Node head;
        private int size;

        private class Node
        {
            /// <summary>
            /// Create new node
            /// </summary>
            /// <param name="value"> Value of new node </param>
            public Node(T value)
            {
                Value = value;
            }

            /// <summary>
            /// Set and get node value
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Get and set next node
            /// </summary>
            public Node Next { get; set; }
        }

        /// <summary>
        /// Add new elemet to list
        /// </summary>
        /// <param name="newElement"> New element to list </param>
        public void Add(T newElement)
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
        public int IndexOf(T element)
        {
            Node temp = head;
            int i = 0;
            while (temp != null)
            {
                if (temp.Value.Equals(element))
                    return i;
                temp = temp.Next;
                ++i;
            }
            throw new ElementDoesNotFoundInListException();
        }

        /// <summary>
        /// Is element contains in list
        /// </summary>
        /// <param name="element"> Element value </param>
        /// <returns> True if element exist in list; else returns false </returns>
        public bool Contains(T element)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Value.Equals(element))
                    return true;
                temp = temp.Next;
            }
            return false;
        }

        /// <summary>
        /// Remove element from list
        /// Throw RemoveNotExistingElementException() if element does not exist
        /// </summary>
        /// <param name="element"> Element value to remove </param>
        public void Remove(T element)
        {
            if (head == null)
                throw new RemoveNotExistingElementException();
            if (head.Value.Equals(element))
            {
                head = head.Next;
                --size;
                return;
            }
            Node temp = head;
            Node secondTemp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
                if (temp.Value.Equals(element))
                {
                    secondTemp.Next = temp.Next;
                    --size;
                    return;
                }
                secondTemp = temp;
            }
            throw new RemoveNotExistingElementException();
        }

        /// <summary>
        /// Returns list size
        /// </summary>
        /// <returns> Size </returns>
        public int GetLength() => size;

        /// <summary>
        /// Returns element in list. Numeration from 0
        /// </summary>
        /// <param name="index"> Index of element </param>
        /// <returns> Value of element or OutOfBoundsOfListException() if index is bigger than list size </returns>
        public T GetElement(int index)
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

        /// <summary>
        /// Implementation for the GetEnumerator method
        /// </summary>
        /// <returns> Enumbertor </returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Enumberator for list
        /// </summary>
        /// <returns> Enumerator </returns>
        public ListEnumerator GetEnumerator() => new ListEnumerator(this);

        /// <summary>
        /// Implementation for list enumberator
        /// </summary>
        public class ListEnumerator : IEnumerator
        {
            private int position = -1;
            private List<T> list;
            private Node currentElement;

            /// <summary>
            /// List enumberator constructor
            /// </summary>
            /// <param name="list"> List for enumeration </param>
            public ListEnumerator(List<T> list)
            {
                this.list = list;
                currentElement = null;
            }

            /// <summary>
            /// Move to next list element
            /// </summary>
            /// <returns> Is position in bounds of list </returns>
            public bool MoveNext()
            {
                ++position;
                currentElement = currentElement == null ? list.head : currentElement.Next;
                return position < list.GetLength();
            }

            /// <summary>
            /// Reset list enumberator
            /// </summary>
            public void Reset()
            {
                currentElement = null;
                position = -1;
            }
            
            /// <summary>
            /// Get current list element
            /// </summary>
            public T Current => currentElement.Value;

            /// <summary>
            /// Get current list element in enumerator
            /// </summary>
            object IEnumerator.Current => currentElement.Value;
        }

    }
}