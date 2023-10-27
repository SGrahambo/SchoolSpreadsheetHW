// <copyright file="OperatorNode.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SpreadsheetEngine;

    /// <summary>
    /// Node that performs operations on other nodes.
    /// </summary>
    public abstract class OperatorNode : Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// Creates an operator node with a character argument.
        /// </summary>
        /// <param name="c"> operator character.</param>
        public OperatorNode(string c)
        {
            this.IsOperand = false;
            this.IsParenthesis = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        public OperatorNode()
        {
            this.IsOperand = false;
            this.IsParenthesis = false;
        }

        /// <summary>
        /// Checks if input char is a valid operator.
        /// </summary>
        /// <param name="c"> char of operator. </param>
        /// <returns> bool. </returns>
        public static bool ValidOperator(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                case '(':
                case ')':
                    return true;
            }

            return false;
        }

        /// <summary>
        /// The operation to do to the nodes children, depending upon the character input.
        /// </summary>
        /// <returns> A double value of the operation. </returns>
        public abstract double Evaluate();
    }
}