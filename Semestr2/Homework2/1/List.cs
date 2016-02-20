using InterfaceList;
using System;

namespace NamespaceList
{
    /// <summary>
    /// Main list class
    /// </summary>
    class List : IList
    {
        private Node head;
        private int size;

        private class Node
        {
            public int value;
            public Node next;
        }
        /// <summary>
        /// List constructor
        /// </summary>
        public List()
        {
            size = 0;
        }

        /// <summary>
        /// Add new elemet to list
        /// </summary>
        /// <param name="newElement"> New Element to list </param>
        public void Add(int newElement)
        {
            Node newNode = new Node();
            newNode.value = newElement;
            if (size == 0)
            {
                head = newNode;
            }
            else
            {
                Node temp = head;
                while (temp.next != null)
                    temp = temp.next;
                temp.next = newNode;
            }
            ++size;
        }

        /// <summary>
        /// Returns first index of element in list
        /// </summary>
        /// <param name="element"> Eelment value </param>
        /// <returns> >=0 if element exist; "-1" if not found </returns>
        public int IndexOf(int element)
        {
            Node temp = head;
            int i = 0;
            while (temp != null)
            {
                if (temp.value == element)
                    return i;
                temp = temp.next;
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
            if (head.value == element)
            {
                head = head.next;
                --size;
                return true;
            }
            Node temp = head;
            Node secondTemp = head;
            while (temp.next != null)
            {
                temp = temp.next;
                if (temp.value == element)
                {
                    secondTemp.next = temp.next;
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
        public int GetLenght()
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
            if (index >= size)
                return Int32.MinValue;
            Node temp = head;
            for (int i = 0; i < index; ++i)
            {
                temp = temp.next;
            }
            return temp.value;
        }
    }
}
