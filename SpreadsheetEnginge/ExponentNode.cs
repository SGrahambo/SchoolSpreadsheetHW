// <copyright file="ExponentNode.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// exponent operator node.
    /// </summary>
    internal class ExponentNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExponentNode"/> class.
        /// </summary>
        public ExponentNode()
        {
            this.Precidence = 3;
        }

        /// <inheritdoc/>
        public override double Evaluate()
        {
            return System.Math.Pow(ExpressionTree.Evaluate(this.Left), ExpressionTree.Evaluate(this.Right));
        }
    }
}