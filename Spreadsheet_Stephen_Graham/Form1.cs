namespace Spreadsheet_Stephen_Graham
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.InitializeDataGrid(28, 26);
        }

        private void InitializeDataGrid(int columns, int rows)
        {
            this.CreateColumns(columns);
            this.CreateRows(rows);
        }

        private void CreateColumns(int columns)
        {
            this.dataGridView1.Columns.Clear();

            // Columns creation. I really wanted to have more than 26 columns. For now at least.
            int columnCount = columns; // number of columns to generate.
            int columnFillWeight = 100;
            int maxColumnCount = 702; // 702 = "ZZ"

            // prevents number of columns from going over the fillwidthlimit (65530) and going past column "ZZ"
            if (columnCount > maxColumnCount)
            {
                columnCount = maxColumnCount;
            }

            if (columnCount > 655)
            {
                columnFillWeight = 93;
            }

            // Column generation
            char columnName1 = 'A';
            char columnName2 = '\0';

            int cc = 0; // column counter
            while (cc < columnCount && (cc < maxColumnCount))
            {
                while ((cc < columnCount) && (columnName1 <= 'Z') && (cc < maxColumnCount))
                {
                    this.dataGridView1.Columns.Add(columnName2.ToString() + columnName1.ToString(), columnName2.ToString() + columnName1.ToString());
                    this.dataGridView1.Columns[cc].FillWeight = columnFillWeight;

                    columnName1++;
                    cc++;
                }

                if (cc == 26)
                {
                    columnName2 = 'A';
                }
                else
                {
                    columnName2++;
                }

                columnName1 = 'A';
            }

            // Column style
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            columnHeaderStyle.Alignment = (DataGridViewContentAlignment)32;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
        }

        private void CreateRows(int rows)
        {
            return;
        }
    }
}
