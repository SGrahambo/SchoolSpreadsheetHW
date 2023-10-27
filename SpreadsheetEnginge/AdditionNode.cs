// <copyright file="AdditionNode.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// addition operator node.
    /// </summary>
    internal class AdditionNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionNode"/> class.
        /// </summary>
        public AdditionNode()
        {
            this.Precidence = 1;
        }

        /// <inheritdoc/>
        public override double Evaluate()
        {
            return ExpressionTree.Evaluate(this.Left) + ExpressionTree.Evaluate(this.Right);
        }
    }
}
