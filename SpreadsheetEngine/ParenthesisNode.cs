// <copyright file="ParenthesisNode.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Parenthesis operator node.
    /// Only openfaced parenthesis "(" create nodes.
    /// </summary>
    internal class ParenthesisNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParenthesisNode"/> class.
        /// </summary>
        public ParenthesisNode()
        {
            this.IsParenthesis = true;
        }

        /// <inheritdoc/>
        public override double Evaluate()
        {
            return 0;
        }
    }
}
