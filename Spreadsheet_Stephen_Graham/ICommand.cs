// <copyright file="ICommand.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace Spreadsheet_Stephen_Graham
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// interface command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// It executes, I guess.
        /// </summary>
        void Execute();

        /// <summary>
        /// I doesn't execute, I guess.
        /// </summary>
        void UnExecute();

        /// <summary>
        /// Description of action.
        /// </summary>
        /// <returns> string of description. </returns>
        string IDescription();
    }
}
