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
        private int BSTsize = 0;

        /// <summary>
        /// Inserts an int value into a BST node.
        /// </summary>
        /// <param name="input"> int value to be inserted to BST. </param>
        public void Insert(int input)
        {
            Node newNode = new Node(input);            

            if (rootNode == null) //checks for empty BST.
            {
                rootNode = newNode;
                BSTsize++;
            }
            else
            {
                Node pointer = rootNode;

                while (true)
                {
                    if (newNode.value <= pointer.value) // duplicates are moved to the right node.
                    {
                        if (pointer.LeftNode == null)
                        {
                            pointer.LeftNode = newNode;
                            BSTsize++;
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
                            BSTsize++;
                            break;
                        }
                        else
                        {
                            pointer = pointer.RightNode;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// returns int of BST size.
        /// </summary>
        /// <returns> int BSTsize. </returns>
        public int GetSize()
        {
            if (rootNode == null)
            {
                return 0;
            }
            else
            {
                return BSTsize;
            }
        }

        /// <summary>
        /// Calls InOrderRecursion with the rootnode as the starting point.
        /// </summary>
        public void ListBST()
        {
            InOrderRecursion(rootNode);
        }

        /// <summary>
        /// Prints the BST list in the order of value.
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
