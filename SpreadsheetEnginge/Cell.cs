// <copyright file="Cell.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Cell abstract class with row and column indexes, text and value propterties.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        private string text = string.Empty;
        private string value = string.Empty;
        private List<Cell> dependents = new List<Cell>();

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets columnIndex.
        /// </summary>
        public abstract int ColumnIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets rowIndex.
        /// </summary>
        public abstract int RowIndex
        {
            get;
            set;
        }

        public string CellName
        {
            get
            {
                string name = string.Empty;
                char column = (char)('A' + this.RowIndex);
                int row = this.ColumnIndex + 1;
                name = column + row.ToString();
                return name;
            }
        }

        /// <summary>
        /// Gets or sets text, and broadcasts change.
        /// </summary>
        public string Text
        {
            get => this.text;

            set
            {
                if (value == this.text)
                {
                    return;
                }
                else
                {
                    this.text = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets cell value, and broadcasts change.
        /// </summary>
        // TODO: the Value property is a getter only and you’ll have to think of a way to allow the Spreadsheet class (more details on this below) to set the value, but no other class can.
        public string Value
        {
            get => this.value;

            set
            {
                if (value == this.value)
                {
                    return;
                }
                else
                {
                    this.value = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public List<Cell> Dependents
        {
            get { return this.dependents; }
        }

        public void AddDependent(Cell dependentCell)
        {
            if (!this.dependents.Contains(dependentCell))
            {
                this.dependents.Add(dependentCell);
            }
        }

        public void RemoveDependent(Cell dependentCell)
        {
            this.dependents.Remove(dependentCell);
        }

        /// <summary>
        /// broadcasts the propertyChanged event with the properies name.
        /// </summary>
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Evaluate(Dictionary<Cell, bool> visitedCells = null)
        {
            if (visitedCells == null)
            {
                visitedCells = new Dictionary<Cell, bool>();
            }

            // Check for circular references
            if (visitedCells.ContainsKey(this))
            {
                // Circular reference detected, set value to error
                this.Value = "ERROR: Circular Reference";
                return;
            }

            visitedCells[this] = true;

            // Notify dependents about the change
            foreach (Cell dependentCell in this.Dependents)
            {
                dependentCell.Evaluate(visitedCells);
            }

            visitedCells.Remove(this);
        }
    }
}
