// <copyright file="CellNonAbstract.cs" company="Stephen Graham - 011706998">
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
    /// Non abstract class of the abstract Cell class.
    /// </summary>
    public class CellNonAbstract : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CellNonAbstract"/> class.
        /// </summary>
        /// <param name="row">Row index.</param>
        /// <param name="column">Column index.</param>
        public CellNonAbstract(int row, int column)
        {
            this.ColumnIndex = column;
            this.RowIndex = row;
        }

        /// <summary>
        /// gets or sets cell column index.
        /// </summary>
        public override int ColumnIndex
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets cell row index.
        /// </summary>
        public override int RowIndex
        {
            get;
            set;
        }
    }
}