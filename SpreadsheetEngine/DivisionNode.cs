// <copyright file="DivisionNode.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// division operator node.
    /// </summary>
    internal class DivisionNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionNode"/> class.
        /// </summary>
        public DivisionNode()
        {
            this.Precidence = 2;
        }

        /// <inheritdoc/>
        public override double Evaluate()
        {
            return ExpressionTree.Evaluate(this.Left) / ExpressionTree.Evaluate(this.Right);
        }
    }
}
