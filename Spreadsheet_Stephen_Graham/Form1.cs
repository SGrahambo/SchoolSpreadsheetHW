// <copyright file="Form1.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace Spreadsheet_Stephen_Graham
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using SpreadsheetEngine;

    /// <summary>
    /// Spreadsheet application GUI.
    /// </summary>
    public partial class Form1 : Form
    {
        private Spreadsheet spreadsheet = new Spreadsheet(100, 50);
        private Stack<ICommand> undos = new Stack<ICommand>();
        private Stack<ICommand> redos = new Stack<ICommand>();

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

            if (e.PropertyName == "BGColor")
            {
                this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor = Color.FromArgb((int)cell.BGColor);
            }
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.spreadsheet.GetCell(e.ColumnIndex, e.RowIndex).Text;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]?.Value != null)
            {
                Cell cell = this.spreadsheet.GetCell(e.ColumnIndex, e.RowIndex);
                cell.Text = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                this.PushUndoText(cell.Text, this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex], "Changed Text");
                this.undoToolStripMenuItem.Enabled = true;
                this.undoToolStripMenuItem.Text = "Undo Changed Text";

                if (cell.Dependents != null)
                {
                    // Notify dependents about the change
                    foreach (Cell dependentCell in cell.Dependents)
                    {
                        dependentCell.Evaluate();
                    }
                }

                // Update the DataGridView cell value
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.Value;
            }
        }

        private void BackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog myDialog = new ColorDialog();

            // Keeps the user from selecting a custom color.
            myDialog.AllowFullOpen = false;

            // Sets the initial color select to the current cell color.
            myDialog.Color = this.dataGridView1.BackgroundColor;

            // Update the text box color if the user clicks OK
            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                this.PushUndo(myDialog.Color, this.dataGridView1.SelectedCells, "Background Color Selection");
                this.undoToolStripMenuItem.Enabled = true;
                this.undoToolStripMenuItem.Text = "Undo Background Colors";

                foreach (DataGridViewCell dataGridCell in this.dataGridView1.SelectedCells)
                {
                    Cell cell = this.spreadsheet.GetCell(dataGridCell.RowIndex, dataGridCell.ColumnIndex);
                    cell.BGColor = (uint)myDialog.Color.ToArgb();
                }
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand undoing = this.undos.Pop();
            this.redos.Push(undoing);
            this.redoToolStripMenuItem.Text = "Redo " + undoing.IDescription();
            undoing.UnExecute();
            this.redoToolStripMenuItem.Enabled = true;

            if (this.undos.Count == 0)
            {
                this.undoToolStripMenuItem.Enabled = false;
                this.undoToolStripMenuItem.Text = "Undo";
            }
        }

        private void PushUndo(System.Drawing.Color color, DataGridViewSelectedCellCollection dataGridCell, string description)
        {
            this.undos.Push(new ICellBGColor(color, dataGridCell, description));
        }

        private void PushUndoText(string inText, System.Windows.Forms.DataGridViewCell dataCell, string description)
        {
            this.undos.Push(new ICellText(inText, dataCell, description));
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand redoing = this.redos.Pop();
            this.undos.Push(redoing);
            this.undoToolStripMenuItem.Text = "Undo " + redoing.IDescription();
            redoing.Execute();
            this.undoToolStripMenuItem.Enabled = true;

            if (this.redos.Count == 0)
            {
                this.redoToolStripMenuItem.Enabled = false;
                this.redoToolStripMenuItem.Text = "Redo";
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream outfile = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
                this.spreadsheet.Save(outfile);

                outfile.Dispose();
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.spreadsheet.ClearCells();
                Stream infile = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                this.spreadsheet.Load(infile);
                Stream file = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                this.spreadsheet.Load(file);
                file.Dispose();
            }

            this.undos.Clear();
            this.redos.Clear();
        }
    }
}
