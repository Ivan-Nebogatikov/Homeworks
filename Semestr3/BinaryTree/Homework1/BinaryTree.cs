using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework1
{
    /// <summary>
    /// Binary Tree realization class
    /// </summary>
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {

        private class Node
        {
            public Node(T newValue, Node parentNode)
            {
                Value = newValue;
                Parent = parentNode;
            }

            public T Value { get; set; }

            public Node LeftChild { get; set; }

            public Node RightChild { get; set; }

            public Node Parent { get; set; }
        }

        private Node root;

        /// <summary>
        /// Add new element to Binary Tree
        /// </summary>
        /// <param name="newValue"> Value of new tree element </param>
        public void Add(T newValue)
        {
            if (root == null)
            {
                root = new Node(newValue, null);
                return;
            }
            var currentNode = root;
            while (true)
            {
                if (currentNode.Value.CompareTo(newValue) == 0)
                {
                    Console.WriteLine("This element already exists in the tree");
                    return;
                }
                if (currentNode.Value.CompareTo(newValue) < 0)
                {
                    if (currentNode.RightChild != null)
                        currentNode = currentNode.RightChild;
                    else
                    {
                        var newNode = new Node(newValue, currentNode);
                        currentNode.RightChild = newNode;
                        break;
                    }
                }
                else
                {
                    if (currentNode.LeftChild != null)
                        currentNode = currentNode.LeftChild;
                    else
                    {
                        var newNode = new Node(newValue, currentNode);
                        currentNode.LeftChild = newNode;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Print all tree elements
        /// </summary>
        public void Print()
        {
            if (root == null)
                Console.Write("Tree is empty");
            else
                PrintChild(root);
            Console.WriteLine();
        }

        private void PrintChild(Node node)
        {
            if (node.LeftChild != null)
                PrintChild(node.LeftChild);
            Console.Write(node.Value + " ");
            if (node.RightChild != null)
                PrintChild(node.RightChild);
        }

        /// <summary>
        /// Checks is tree empty
        /// </summary>
        /// <returns> True if there are no elements in the tree </returns>
        public bool IsEmpty() => root == null;

        /// <summary>
        /// Checks if element exists in the tree
        /// </summary>
        /// <param name="value"> Value of checking element </param>
        /// <returns> True if element exists; False - else </returns>
        public bool Contains(T value)
        {
            var node = root;
            while (true)
            {
                if (node == null)
                    return false;
                if (node.Value.CompareTo(value) == 0)
                    return true;
                node = node.Value.CompareTo(value) < 0 ? node.RightChild : node.LeftChild;
            }
        }

        /// <summary>
        /// Deleting element from tree
        /// </summary>
        /// <param name="value"> Value of deleting element </param>
        public void Delete(T value) => DeleteFromTree(ref root, value);

        private void DeleteFromTree(ref Node node, T value)
        {
            if (node == null)
                return;
            if (node.Value.CompareTo(value) == 0)
            {
                if (node.LeftChild == null && node.RightChild == null)
                {
                    if (node.Parent == null)
                        node = null;
                    else
                        if (node.Parent.Value.CompareTo(node.Value) > 0)
                        node.Parent.LeftChild = null;
                    else
                        node.Parent.RightChild = null;
                    return;
                }
                if (node.LeftChild != null && node.RightChild == null)
                {
                    if (node.Parent == null)
                    {
                        node.LeftChild.Parent = null;
                        node = node.LeftChild;
                    }
                    else
                        if (node.Parent.Value.CompareTo(node.Value) > 0)
                    {
                        node.Parent.LeftChild = node.LeftChild;
                        node.LeftChild.Parent = node.Parent;
                    }
                    else
                    {
                        node.Parent.RightChild = node.LeftChild;
                        node.LeftChild.Parent = node.Parent;
                    }
                    return;
                }
                if (node.LeftChild == null && node.RightChild != null)
                {
                    if (node.Parent == null)
                    {
                        node.RightChild.Parent = null;
                        node = node.RightChild;
                    }
                    else
                        if (node.Parent.Value.CompareTo(node.Value) > 0)
                    {
                        node.Parent.LeftChild = node.RightChild;
                        node.RightChild.Parent = node.Parent;
                    }
                    else
                    {
                        node.Parent.RightChild = node.RightChild;
                        node.RightChild.Parent = node.Parent;
                    }
                    return;
                }
                var tempNode = node.LeftChild;
                while (tempNode.LeftChild != null || tempNode.RightChild != null)
                {
                    tempNode = tempNode.RightChild ?? tempNode.LeftChild;
                }
                if (tempNode.Parent.Value.CompareTo(tempNode.Value) < 0)
                    tempNode.Parent.RightChild = null;
                else
                    tempNode.Parent.LeftChild = null;
                tempNode.Parent = null;
                node.Value = tempNode.Value;
            }
            else
            {
                var newNode = node.Value.CompareTo(value) > 0 ? node.LeftChild : node.RightChild;
                DeleteFromTree(ref newNode, value);
            }
        }


        private class TreeIterator : IEnumerator<T>
        {
            private readonly List<T> treeList;
            private int index = -1;

            /// <summary>
            /// Tree iterator constructor
            /// </summary>
            /// <param name="binaryTree"> Tree for enumeration </param>
            public TreeIterator(BinaryTree<T> binaryTree)
            {
                treeList = new List<T>();
                GenerateList(binaryTree.root);
            }

            private void GenerateList(Node node)
            {
                if (node.LeftChild != null)
                    GenerateList(node.LeftChild);
                treeList.Add(node.Value);
                if  (node.RightChild != null)
                    GenerateList(node.RightChild);
            }

            /// <summary>
            /// Disposing enumerator
            /// </summary>
            public void Dispose()
            {
            }

            /// <summary>
            /// Move to next tree element
            /// </summary>
            /// <returns> Is position in bounds of tree elements </returns>
            public bool MoveNext()
            {
                ++index;
                return treeList.Count > index;
            }

            /// <summary>
            /// Reset list enumberator
            /// </summary>
            public void Reset()
            {
                index = -1;
            }

            /// <summary>
            /// Get current tree element
            /// </summary>
            public T Current => treeList[index];

            /// <summary>
            /// Get current tree element in enumerator
            /// </summary>
            object IEnumerator.Current => Current;
        }

        /// <summary>
        /// Enumerator for generic collection
        /// </summary>
        /// <returns> Enumerator </returns>
        public IEnumerator<T> GetEnumerator() => new TreeIterator(this);
        
        /// <summary>
        /// Enumerator for collection
        /// </summary>
        /// <returns> Enumerator of tree </returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
