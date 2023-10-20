// <copyright file="Node.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// abstract node for expression tree.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Gets or Sets the left child.
        /// </summary>
        public Node Left { get; set; }

        /// <summary>
        /// Gets or Sets the right child.
        /// </summary>
        public Node Right { get; set; }

        /// <summary>
        /// Gets or Sets the precident of the node.
        /// </summary>
        public int Precidence { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether node contains an operand.
        /// </summary>
        public bool IsOperand { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if node contains a parenthesis.
        /// </summary>
        public bool IsParenthesis { get; set; }
    }
}