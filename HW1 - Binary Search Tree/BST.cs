using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___Binary_Search_Tree
{
    class BST
    {
        private Node rootNode;
        private int BSTSize = 0;
        private int BSTHeight = 0;

        /// <summary>
        /// Inserts an int value into a BST node.
        /// </summary>
        /// <param name="input"> int value to be inserted to BST. </param>
        public void Insert(int input)
        {
            Node newNode = new Node(input);
            int currentHeight = 1;

            if (rootNode == null) //checks for empty BST.
            {
                rootNode = newNode;
                BSTSize++;
                BSTHeight++;
            }
            else
            {
                Node pointer = rootNode;
                while (true)
                {
                    currentHeight++;
                    if (newNode.value <= pointer.value) // duplicates are moved to the right node.
                    {
                        if (pointer.LeftNode == null)
                        {
                            pointer.LeftNode = newNode;
                            BSTSize++;
                            break;
                        }
                        else
                        {
                            pointer = pointer.LeftNode;
                        }
                    } 
                    else if (newNode.value > pointer.value)
                    {
                        if (pointer.RightNode == null)
                        {
                            pointer.RightNode = newNode;
                            BSTSize++;
                            break;
                        }
                        else
                        {
                            pointer = pointer.RightNode;
                        }
                    }
                }
                if (currentHeight > BSTHeight)
                {
                    BSTHeight = currentHeight;
                }
            }
        }

        /// <summary>
        /// returns int of BST size.
        /// </summary>
        /// <returns> int BSTSize. </returns>
        public int GetSize()
        {
            return BSTSize;
        }

        /// <summary>
        /// Returns the int of the minimum height of a tree if it was balanced.
        /// minimum formula taken from: https://www.geeksforgeeks.org/relationship-number-nodes-height-binary-tree/
        /// </summary>
        /// <returns> (int)Math.Log(BSTSize, 2) + 1 </returns>
        public int GetMinHeight()
        {
            if (rootNode == null)
            {
                return 0;
            }
            else
            {
                return (int)Math.Log(BSTSize, 2) + 1;
            }
        }

        public int GetHeight()
        {
            return BSTHeight;
        }

        /// <summary>
        /// Calls InOrderRecursion with the rootnode as the starting point.
        /// </summary>
        public void ListBST()
        {
            InOrderRecursion(rootNode);
        }

        /// <summary>
        /// Prints the BST list in the order of values.
        /// </summary>
        /// <param name="pointer"> Starting point of the BST traversal (ideally the root node). </param>
        private void InOrderRecursion(Node pointer)
        {
            if (rootNode == null)
            {
                Console.WriteLine("Tree is empty.");
            }
            else if (pointer != null)
            {
                InOrderRecursion(pointer.LeftNode);
                Console.Write(pointer.value + " ");
                InOrderRecursion(pointer.RightNode);
            }
        }
    }
}
