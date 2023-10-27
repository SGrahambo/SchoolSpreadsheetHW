// <copyright file="SubtractionNode.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Subraction operator node.
    /// </summary>
    internal class SubtractionNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractionNode"/> class.
        /// </summary>
        public SubtractionNode()
        {
            this.Precidence = 1;
        }

        /// <inheritdoc/>
        public override double Evaluate()
        {
            return ExpressionTree.Evaluate(this.Left) - ExpressionTree.Evaluate(this.Right);
        }
    }
}
