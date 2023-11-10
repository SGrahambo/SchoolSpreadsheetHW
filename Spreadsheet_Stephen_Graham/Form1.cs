// <copyright file="Form1.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

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
    using SpreadsheetEngine;

    /// <summary>
    /// Spreadsheet application GUI.
    /// </summary>
    public partial class Form1 : Form
    {
        private Spreadsheet spreadsheet = new Spreadsheet(100, 50);

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.InitializeDataGrid(50, 26);
        }

        private void InitializeDataGrid(int columns, int rows)
        {
            this.CreateColumns(columns);
            this.CreateRows(rows);
        }

        private void ClearDataGrid()
        {
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();
        }

        /// <summary>
        /// Creates input number of columns from A to Z, then from AA to ZZ (max 702 columns).
        /// </summary>
        /// <param name="columns"> the number of columns to create. </param>
        private void CreateColumns(int columns)
        {
            this.dataGridView1.Columns.Clear();
            int maxColumnCount = 702; // 702 = "ZZ"
            int columnFillWeight = 100;

            // prevents number of columns from going over the fillwidthlimit (65530) and going past column "ZZ"
            if (columns > maxColumnCount)
            {
                columns = maxColumnCount;
            }

            // (when large number of columns) smaller columns to acomodate max datagridview size.
            if (columns > 655)
            {
                columnFillWeight = 93;
            }

            // Column generation
            char columnName1 = 'A';
            char columnName2 = '\0';

            int cc = 0; // column counter
            while (cc < columns && (cc < maxColumnCount))
            {
                while ((cc < columns) && (columnName1 <= 'Z') && (cc < maxColumnCount))
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
            this.dataGridView1.Rows.Clear();
            if (rows <= 1)
            {
                rows = 1;
            }
            else
            {
                this.dataGridView1.Rows.Add(rows - 1);
            }

            for (int i = 0; i < rows; i++)
            {
                int rowName = i + 1;
                this.dataGridView1.Rows[i].HeaderCell.Value = rowName.ToString();
            }
        }

        private void DemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.spreadsheet.Demo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitializeDataGrid(this.spreadsheet.ColumnCount, this.spreadsheet.RowCount);
            this.spreadsheet.CellPropertyChanged += this.Form1PropertyChanged;
        }

        // subscribes to propertychanged of the cell class
        private void Form1PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell cell = (Cell)sender;

            if (e.PropertyName == "Value")
            {
                this.dataGridView1.Rows[cell.ColumnIndex].Cells[cell.RowIndex].Value = cell.Value;
            }
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.spreadsheet.GetCell(e.ColumnIndex, e.RowIndex).Text;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Cell cell = this.spreadsheet.GetCell(e.ColumnIndex, e.RowIndex);

            if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
            {
                cell.Text = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else
            {
                cell.Text = string.Empty;
            }

            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.Value;
        }
    }
}
