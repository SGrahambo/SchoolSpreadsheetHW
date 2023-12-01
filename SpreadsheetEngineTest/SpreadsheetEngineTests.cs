// <copyright file="SpreadsheetEngineTests.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests classes and methods in the SpreadsheetEngine Library.
    /// </summary>
    public class SpreadsheetEngineTests
    {
        private Cell[,] cells;

        /// <summary>
        /// makes 3x2 grid of cells. Creates and tests text in each cell.
        /// </summary>
        [Test]
        public void CellGridTextTest()
        {
            int columns = 3;
            int rows = 2;
            this.cells = new Cell[columns, rows];
            for (int iColumn = 0; iColumn < columns; iColumn++)
            {
                for (int iRow = 0; iRow < rows; iRow++)
                {
                    this.cells[iColumn, iRow] = new CellNonAbstract(iColumn, iRow);
                }
            }

            Cell cell = this.cells[0, 0];
            Assert.That(this.cells[0, 0].Text, Is.EqualTo(string.Empty));

            cell = this.cells[0, 1];
            cell.Text = "test01";
            Assert.That(this.cells[0, 1].Text, Is.EqualTo("test01"));

            cell = this.cells[1, 0];
            cell.Text = "test10";
            Assert.That(this.cells[1, 0].Text, Is.EqualTo("test10"));

            cell = this.cells[1, 1];
            cell.Text = "test11";
            Assert.That(this.cells[1, 1].Text, Is.EqualTo("test11"));

            cell = this.cells[2, 1];
            cell.Text = "test21";
            Assert.That(this.cells[2, 1].Text, Is.EqualTo("test21"));
            Assert.That(this.cells[2, 0].Text, Is.EqualTo(string.Empty));
        }

        /// <summary>
        /// Makes a 3x2 grid through the spreadsheet class and tests each cells text values.
        /// </summary>
        [Test]
        public void SpreadsheetGridTextTest()
        {
            Spreadsheet spreadsheet = new Spreadsheet(3, 2);

            Cell cell = spreadsheet.GetCell(0, 0);
            Assert.That(cell.Text, Is.EqualTo(string.Empty));

            cell = spreadsheet.GetCell(0, 1);
            cell.Text = "test01";
            Assert.That(cell.Text, Is.EqualTo("test01"));

            cell = spreadsheet.GetCell(1, 0);
            cell.Text = "test10";
            Assert.That(cell.Text, Is.EqualTo("test10"));

            cell = spreadsheet.GetCell(1, 1);
            cell.Text = "test11";
            Assert.That(cell.Text, Is.EqualTo("test11"));

            cell = spreadsheet.GetCell(2, 0);
            Assert.That(cell.Text, Is.EqualTo(string.Empty));

            cell = spreadsheet.GetCell(2, 1);
            cell.Text = "test21";
            Assert.That(cell.Text, Is.EqualTo("test21"));
        }

        /// <summary>
        /// Tests if value of a spreadsheet cell matches text.
        /// </summary>
        [Test]
        public void SpreadsheetValueTest()
        {
            Spreadsheet spreadsheet = new Spreadsheet(3, 2);

            Cell cell = spreadsheet.GetCell(0, 0);
            cell.Text = "Equal Test00";

            Assert.That(cell.Value, Is.EqualTo("Equal Test00"));
        }

        /// <summary>
        /// Tests if the value of a spreadsheet cells with text "=A1" equals the value of cell A1.
        /// </summary>
        [Test]
        public void EqualValueTest()
        {
            Spreadsheet spreadsheet = new Spreadsheet(3, 2);

            Cell cell = spreadsheet.GetCell(0, 0);
            cell.Text = "Equal Test00";

            cell = spreadsheet.GetCell(2, 1);
            cell.Text = "=A1";

            Assert.That(cell.Value, Is.EqualTo("Equal Test00"));
        }

        /// <summary>
        /// Tests if a spreadsheet cell with text "=AB1" will equal the value of cell AB1.
        /// </summary>
        [Test]
        public void EqualValueLargeColumnTest()
        {
            Spreadsheet spreadsheet = new Spreadsheet(40, 2);

            Cell cell = spreadsheet.GetCell(0, 27);
            cell.Text = "Equal Test AB1";

            cell = spreadsheet.GetCell(1, 1);
            cell.Text = "=AB1";

            Assert.That(cell.Value, Is.EqualTo("Equal Test AB1"));
        }

        /// <summary>
        /// If the value of a cell with text "=A1" will have an empty value if cell A1 is empty.
        /// </summary>
        [Test]
        public void EqualEmptyCellTest()
        {
            int columns = 3;
            int rows = 2;
            this.cells = new Cell[columns, rows];
            for (int iColumn = 0; iColumn < columns; iColumn++)
            {
                for (int iRow = 0; iRow < rows; iRow++)
                {
                    this.cells[iColumn, iRow] = new CellNonAbstract(iColumn, iRow);
                }
            }

            Cell cell = this.cells[2, 1];
            cell.Text = "=A1";

            Assert.That(this.cells[0, 0].Value, Is.EqualTo(string.Empty));
        }

        [TestCase(0, 0, "A1")]
        [TestCase(0, 1, "A2")]
        [TestCase(1, 0, "B1")]
        [TestCase(1, 1, "B2")]
        [TestCase(2, 0, "C1")]
        [TestCase(2, 1, "C2")]
        public void CellNameTest(int col, int row, string name)
        {
            int columns = 3;
            int rows = 2;
            this.cells = new Cell[columns, rows];
            for (int iColumn = 0; iColumn < columns; iColumn++)
            {
                for (int iRow = 0; iRow < rows; iRow++)
                {
                    this.cells[iColumn, iRow] = new CellNonAbstract(iColumn, iRow);
                }
            }

            Assert.That(this.cells[col, row].CellName, Is.EqualTo(name));
        }
    }


}