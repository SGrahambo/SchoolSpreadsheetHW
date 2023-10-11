namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    //using SpreadsheetEngine;

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

        public override int ColumnIndex
        {
            get;
            set;
        }

        public override int RowIndex
        {
            get;
            set;
        }
    }
}