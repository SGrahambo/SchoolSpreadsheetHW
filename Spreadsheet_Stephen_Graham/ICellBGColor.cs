// <copyright file="ICellBGColor.cs" company="Stephen Graham - 011706998">
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
    /// undo and redo of cell colors.
    /// </summary>
    public class ICellBGColor : ICommand
    {
        private string iDescription;
        private System.Windows.Forms.DataGridViewSelectedCellCollection cells;
        private System.Drawing.Color color;
        private List<System.Drawing.Color> prevColors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ICellBGColor"/> class.
        /// </summary>
        /// <param name="color"> System.Drawing.Color color. </param>
        /// <param name="cells"> DataGridViewSelectedCellCollection cells. </param>
        /// <param name="description"> string description. </param>
        public ICellBGColor(System.Drawing.Color color, System.Windows.Forms.DataGridViewSelectedCellCollection cells, string description)
        {
            this.cells = cells;
            this.color = color;
            this.iDescription = description;
            this.prevColors = new List<System.Drawing.Color>();

            foreach (System.Windows.Forms.DataGridViewCell dataGridCell in this.cells)
            {
                this.prevColors.Add(dataGridCell.Style.BackColor);
            }
        }

        /// <summary>
        /// Adds color to undo list.
        /// </summary>
        public void Execute()
        {
            foreach (System.Windows.Forms.DataGridViewCell dataGridCell in this.cells)
            {
                this.prevColors.Add(dataGridCell.Style.BackColor);
                dataGridCell.Style.BackColor = this.color;
            }
        }

        /// <summary>
        /// removes color from undo list and applies it to cell.
        /// </summary>
        public void UnExecute()
        {
            int i = 0;
            foreach (System.Windows.Forms.DataGridViewCell dataGridCell in this.cells)
            {
                dataGridCell.Style.BackColor = this.prevColors[i];
                i++;
            }
        }

        /// <summary>
        /// Description of action.
        /// </summary>
        /// <returns> entered description. </returns>
        public string IDescription()
        {
            return this.iDescription;
        }
    }
}
