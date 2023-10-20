// <copyright file="VariableNode.cs" company="Stephen Graham - 011706998">
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
    /// Node containing a variable value.
    /// </summary>
    public class VariableNode : Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name"> name of the variable. </param>
        public VariableNode(string name)
        {
            this.Name = name;
            this.Precidence = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        public VariableNode()
        {
            this.Precidence = 0;
        }

        /// <summary>
        /// Gets or sets the name of the Variable Node.
        /// </summary>
        public string Name { get; set; }
    }
}