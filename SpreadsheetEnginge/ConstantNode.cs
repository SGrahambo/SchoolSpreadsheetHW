// <copyright file="ConstantNode.cs" company="Stephen Graham - 011706998">
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
    /// Node with a constant value.
    /// </summary>
    public class ConstantNode : Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// Creates a node with the given parameter value.
        /// </summary>
        /// <param name="value"> constant value. </param>
        public ConstantNode(double value)
        {
            this.Value = value;
            this.Precidence = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        public ConstantNode()
        {
            this.Precidence = 0;
        }

        /// <summary>
        /// Gets or Sets the node value.
        /// </summary>
        public double Value { get; set; }
    }

}
