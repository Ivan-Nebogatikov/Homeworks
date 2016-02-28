using System;

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
            private int number;
            private Node next;

            /// <summary>
            /// Create new node
            /// </summary>
            /// <param name="value"> Value of new node </param>
            public Node(int value)
            {
                number = value;
            }

            /// <summary>
            /// Set and get node value
            /// </summary>
            public int Value
            {
                get { return number; }
                set { number = value; }
            }

            /// <summary>
            /// Get and set next node
            /// </summary>
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
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
        /// <param name="newElement"> New Element to list </param>
        public void Add(int newElement)
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
        /// <returns> >=0 if element exist; "-1" if not found </returns>
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
            return -1;
        }

        /// <summary>
        /// Remove element from list
        /// </summary>
        /// <param name="element"> Element value to remove </param>
        /// <returns> True is removing succeeded else returns false </returns>
        public bool Remove(int element)
        {
            if (head == null)
                return false;
            if (head.Value == element)
            {
                head = head.Next;
                --size;
                return true;
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
                    return true;
                }
                secondTemp = temp;
            }
            return false;
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
        /// <returns> Int value or Int32.MinValue if index is bigger than list size </returns>
        public int GetElement(int index)
        {
            if (index >= size || index < 0)
                return Int32.MinValue;
            Node temp = head;
            for (int i = 0; i < index; ++i)
            {
                temp = temp.Next;
            }
            return temp.Value;
        }
    }
}