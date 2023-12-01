﻿// <copyright file="Spreadsheet.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Spreadsheet engine for spreadsheet application.
    /// </summary>
    public class Spreadsheet
    {
        private int numColumns;
        private int numRows;
        private Cell[,] cells;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// Creates a spreadsheet.
        /// </summary>
        /// <param name="columnCount">The number of columns.</param>
        /// <param name="rowCount">The number of rows.</param>
        /// <returns> A 2D array of cells. </returns>
        public Spreadsheet(int columnCount, int rowCount)
        {
            this.numRows = rowCount;
            this.numColumns = columnCount;

            this.cells = new Cell[columnCount, rowCount];

            for (int iColumn = 0; iColumn < columnCount; iColumn++)
            {
                for (int iRow = 0; iRow < rowCount; iRow++)
                {
                    this.cells[iColumn, iRow] = new CellNonAbstract(iColumn, iRow);
                    this.cells[iColumn, iRow].PropertyChanged += this.CellPropertyChangedMethod;
                }
            }
        }

        /// <summary>
        /// Creates Property Changed event handler.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Gets the total number of columns.
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return this.numColumns;
            }
        }

        /// <summary>
        /// Gets the total number of rows.
        /// </summary>
        public int RowCount
        {
            get
            {
                return this.numRows;
            }
        }

        /// <summary>
        /// Sets all cells to empty.
        /// </summary>
        public void ClearCells()
        {
            for (int iColumn = 0; iColumn < this.numColumns; iColumn++)
            {
                for (int iRow = 0; iRow < this.numRows; iRow++)
                {
                    this.cells[iColumn, iRow].Text = string.Empty;
                    this.cells[iColumn, iRow].BGColor = 0xFFFFFFFF;
                    this.cells[iColumn, iRow].PropertyChanged += this.CellPropertyChangedMethod;
                }
            }
        }

        /// <summary>
        /// Returns a cell object with the specified indexes.
        /// </summary>
        /// <param name="iColumn">Column index.</param>
        /// <param name="iRow">Row index.</param>
        /// <returns>The Cell Object.</returns>
        public Cell GetCell(int iColumn, int iRow)
        {
            if (this.IsValidCellIndex(iColumn, iRow))
            {
                return this.cells[iColumn, iRow];
            }
            else
            {
                throw new ArgumentException("Invalid cell reference");
            }
        }

        /// <summary>
        /// Returns a cell object by converting the cell name to indexes.
        /// </summary>
        /// <param name="name"> CellName. </param>
        /// <returns> Cell Object. </returns>
        public Cell GetCell(string name)
        {
            char columnLetter = name[0];
            int row;

            if (!char.IsLetter(columnLetter) || !int.TryParse(name.Substring(1), out row))
            {
                throw new ArgumentException("Invalid cell reference");
            }

            return this.GetCell(columnLetter - 'A', row - 1);
        }

        private bool IsValidCellIndex(int iColumn, int iRow)
        {
            return iColumn >= 0 && iColumn < this.ColumnCount && iRow >= 0 && iRow < this.RowCount;
        }

        /// <summary>
        /// Saves the spreadsheet data to an XML file.
        /// </summary>
        /// <param name="outfile"> .xml file. </param>
        public void Save(Stream outfile)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writeXml = XmlWriter.Create(outfile, settings);

            writeXml.WriteStartElement("spreadsheet");

            foreach (Cell cell in this.cells)
            {
                if (cell.Text != string.Empty || cell.Value != string.Empty || cell.BGColor != 4294967295)
                {
                    writeXml.WriteStartElement("cell");
                    writeXml.WriteAttributeString("name", cell.CellName);
                    writeXml.WriteElementString("text", cell.Text.ToString());
                    writeXml.WriteElementString("bgcolor", cell.BGColor.ToString("x8"));
                    writeXml.WriteEndElement();
                }
            }

            writeXml.WriteEndElement();
            writeXml.Close();
        }

        /// <summary>
        /// Loads XML file to spreadsheet.
        /// </summary>
        /// <param name="infile"> .xml file. </param>
        public void Load(Stream infile)
        {
            XDocument inf = XDocument.Load(infile);

            foreach (XElement label in inf.Root.Elements("cell"))
            {
                Cell cell = this.GetCell(label.Attribute("name").Value);

                if (label.Element("text") != null)
                {
                    cell.Text = label.Element("text").Value.ToString();
                }

                if (label.Element("bgcolor") != null)
                {
                    cell.BGColor = uint.Parse(label.Element("bgcolor").Value, System.Globalization.NumberStyles.HexNumber);
                }
            }
        }

        // does something each time a cell is changed.
        private void CellPropertyChangedMethod(object sender, PropertyChangedEventArgs e)
        {
            Cell cell = (Cell)sender;

            // does stuff if cell text is changed.
            if (e.PropertyName == "Text")
            {
                if (cell.Text.StartsWith("="))
                {
                    this.Evaluate(cell);

                    string columnStr = string.Empty;
                    string rowStr = string.Empty;

                    // gets cell index from cell text
                    string text = cell.Text.TrimStart('=');
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (char.IsLetter(text[i]))
                        {
                            columnStr += text[i];
                        }
                        else if (char.IsNumber(text[i]))
                        {
                            rowStr += text[i];
                        }
                    }

                    int iRow = int.Parse(rowStr) - 1;
                    int iColumn;

                    if (columnStr.Length == 2)
                    {
                        iColumn = (26 * (char.ToUpper(columnStr[0]) - 64)) + (char.ToUpper(columnStr[1]) - 65);
                    }
                    else
                    {
                        iColumn = char.ToUpper(columnStr[0]) - 65;
                    }

                    cell.Value = this.GetCell(iColumn, iRow).Value;
                }
                else
                {
                    cell.Value = cell.Text;
                }
            }

            // I think this informs other referencing cells that this cells value was changed if I follow the logic right.
            this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));

            if (e.PropertyName == "BGColor")
            {
                this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("BGColor"));
            }
        }

        private void Evaluate(Cell cell)
        {
            ExpressionTree expressionTree = new ExpressionTree(cell.Text.Substring(1));

            cell.Value = expressionTree.Evaluate().ToString();
        }

        /// <summary>
        /// Demonstrates changing cell values and referencing other cells.
        /// </summary>
        public void Demo()
        {
            this.ClearCells();
            int numRandomCells = 500;
            Random random = new Random();

            // fill random cells with a message.
            for (int i = 0; i < numRandomCells; i++)
            {
                int randomColumn = random.Next(0, this.ColumnCount);
                int randomRow = random.Next(0, this.RowCount);

                Cell cell = this.GetCell(randomColumn, randomRow);
                cell.Text = "It worked.";
            }

            // fills column B with text declaring its cell location.
            for (int i = 0; i < this.RowCount; i++)
            {
                Cell cell = this.GetCell(1, i);
                cell.Text = "This is cell B" + (i + 1);
            }

            // Fills column A with what value is in adjacent column B
            for (int i = 0; i < this.RowCount; i++)
            {
                Cell cell = this.GetCell(0, i);
                cell.Text = "=B" + (i + 1);
            }

            // Fills column C with what value is in ajacent column D (to test empty cells).
            for (int i = 0; i < this.RowCount; i++)
            {
                Cell cell = this.GetCell(2, i);
                if (i == 0)
                {
                    cell.Text = "Copies column D";
                }
                else
                {
                    cell.Text = "=D" + (i + 1);
                }
            }
        }
    }
}
