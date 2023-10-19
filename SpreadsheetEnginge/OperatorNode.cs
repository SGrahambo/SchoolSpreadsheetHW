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

    /// <summary>
    /// Node that performs operations on other nodes.
    /// </summary>
    public class OperatorNode : Node
    {
        private static List<char> validOperators = new List<char> { '+', '-', '*', '/' };

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// Creates an operator node with a character argument.
        /// </summary>
        /// <param name="c"> operator character.</param>
        public OperatorNode(string c)
        {
            this.Operator = c;
            this.Precidence = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        public OperatorNode()
        {
            this.Precidence = 1;
        }

        /// <summary>
        /// Gets or sets the operator node.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Returns true if operator is from valid list.
        /// </summary>
        /// <param name="c"> Char of operator.</param>
        /// <returns> bool. </returns>
        public static bool ValidOperators(char c)
        {
            if (validOperators.Contains(c))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The operation to do to the nodes children, depending upon the character input.
        /// </summary>
        /// <returns> A double value of the operation. </returns>
        public double Operate()
        {
            switch (this.Operator)
            {
                case "+":
                    return ExpressionTree.Evaluate(this.Left) + ExpressionTree.Evaluate(this.Right);
                case "-":
                    return ExpressionTree.Evaluate(this.Left) - ExpressionTree.Evaluate(this.Right);
                case "*":
                    return ExpressionTree.Evaluate(this.Left) * ExpressionTree.Evaluate(this.Right);
                case "/":
                    return ExpressionTree.Evaluate(this.Left) / ExpressionTree.Evaluate(this.Right);
                default:
                    throw new NotSupportedException(
                           "Operator " + this.Operator.ToString() + " not supported.");
            }
        }
    }
}
