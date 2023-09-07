using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___Binary_Search_Tree
{
    /// <summary>
    /// 
    /// </summary>
    class Node
    {
        public int value;
        public Node LeftNode;
        public Node RightNode;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public Node(int input)
        {
            this.value = input;
        }
    }

}
