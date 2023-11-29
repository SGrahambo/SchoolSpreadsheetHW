// <copyright file="MultiplicationNode.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// multiplication operator node.
    /// </summary>
    internal class MultiplicationNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplicationNode"/> class.
        /// </summary>
        public MultiplicationNode()
        {
            this.Precidence = 2;
        }

        /// <inheritdoc/>
        public override double Evaluate()
        {
            return ExpressionTree.Evaluate(this.Left) * ExpressionTree.Evaluate(this.Right);
        }
    }
}
