﻿namespace Problem2
{
    /// <summary>
    /// Main list class
    /// </summary>
    public class List : IList
    {
        protected Node head;
        protected int size;

        protected class Node
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
            Node newNode = new Node(newElement);
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
        public virtual int IndexOf(int element)
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
        /// <param name="element"> Element value to remove </param>
        public virtual void Remove(int element)
        {
            if (head == null)
                throw new RemoveNotExistingElementException();
            if (head.Value == element)
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
                if (temp.Value == element)
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
        public virtual int GetLength()
        {
            return size;
        }

        /// <summary>
        /// Returns element in list. Numeration from 0
        /// </summary>
        /// <param name="index"> Index of element </param>
        /// <returns> Int value or OutOfBoundsOfListException() if index is bigger than list size </returns>
        public virtual int GetElement(int index)
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