// <copyright file="ICellText.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace Spreadsheet_Stephen_Graham
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SpreadsheetEngine;

    /// <summary>
    /// Cell value undo/redo.
    /// </summary>
    public class ICellText : ICommand
    {
        private System.Windows.Forms.DataGridViewCell cell;
        private string iDescription;
        private string newText;
        private List<string> prevText;

        /// <summary>
        /// Initializes a new instance of the <see cref="ICellText"/> class.
        /// </summary>
        /// <param name="inText"> Text to be added to undo. </param>
        /// <param name="cell"> Cell being undone. </param>
        /// <param name="description"> Description of action. </param>
        public ICellText(string inText, System.Windows.Forms.DataGridViewCell cell, string description)
        {
            this.prevText = new List<string>();
            this.newText = inText;
            this.cell = cell;
            this.iDescription = description;
            this.prevText.Add(cell.Value.ToString());
        }

        /// <summary>
        /// Adds cell value to undo list.
        /// </summary>
        public void Execute()
        {
            this.prevText.Add(this.cell.Value.ToString());
            this.cell.Value = this.newText;
        }

        /// <summary>
        /// removes cell value from undo list and applies it to cell.
        /// </summary>
        public void UnExecute()
        {
            this.cell.Value = this.prevText;
        }

        /// <summary>
        /// action description.
        /// </summary>
        /// <returns> string of entered description. </returns>
        public string IDescription()
        {
            return this.iDescription;
        }
    }
}
