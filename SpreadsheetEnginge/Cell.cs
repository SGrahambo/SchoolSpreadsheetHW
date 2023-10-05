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
        protected string text = string.Empty;
        protected string value = string.Empty;
        private readonly int columnIndex;
        private readonly int rowIndex;

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

        /// <summary>
        /// broadcasts the propertyChanged event with the properies name.
        /// </summary>
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
