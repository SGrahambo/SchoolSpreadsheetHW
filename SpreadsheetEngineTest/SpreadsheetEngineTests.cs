// <copyright file="SpreadsheetEngineTests.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Tests
{
    using NUnit.Framework;

    public class SpreadsheetEngineTests
    {
        private Cell[,] cells;

        [SetUp]
        public void Setup()
        {
        }

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

        [Test]
        public void CellValueTest()
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
            cell.Text = "Equal Test00";

            Assert.That(this.cells[0, 0].Value, Is.EqualTo("Equal Test00"));
        }

        [Test]
        public void EqualValueTest()
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
            cell.Text = "Equal Test00";

            cell = this.cells[2, 1];
            cell.Text = "=A1";

            Assert.That(this.cells[2, 1].Value, Is.EqualTo("Equal Test00"));
        }

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
    }
}