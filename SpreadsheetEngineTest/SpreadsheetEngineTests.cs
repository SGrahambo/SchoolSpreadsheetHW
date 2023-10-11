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
        /// makes 2x2 grid of cells.
        /// </summary>
        [Test]
        public void CellGridTest()
        {
            int columns = 2;
            int rows = 2;
            this.cells = new Cell[columns, rows];
            for (int iColumn = 0; iColumn < columns; iColumn++)
            {
                for (int iRow = 0; iRow < rows; iRow++)
                {
                    this.cells[iRow, iColumn] = new CellNonAbstract(iRow, iColumn);
                }
            }

            Cell cell = this.cells[0, 0];
            cell.Text = "test00";
            Assert.That(this.cells[0, 0].Text, Is.EqualTo("test00"));

            cell = this.cells[0, 1];
            cell.Text = "test01";
            Assert.That(this.cells[0, 1].Text, Is.EqualTo("test01"));

            cell = this.cells[1, 0];
            cell.Text = "test10";
            Assert.That(this.cells[1, 0].Text, Is.EqualTo("test10"));

            cell = this.cells[1, 1];
            cell.Text = "test11";
            Assert.That(this.cells[1, 1].Text, Is.EqualTo("test11"));
        }
    }
}