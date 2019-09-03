// <copyright file="Cell.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// An abstract class in charge of the cells components
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Keeps track of the text property in the cell
        /// </summary>
        protected string text;

        /// <summary>
        /// Keeps track of the value property in the cell
        /// </summary>
        protected string value;

        /// <summary>
        /// Keeps track of the row index
        /// </summary>
        private int rowIndex;

        /// <summary>
        /// Keeps track of the column index
        /// </summary>
        private int columnIndex;

        private uint color = 4294967295;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// Constructor for the row index and column index, acts as the setter
        /// </summary>
        /// <param name="newRow">Gets assigned to the row index</param>
        /// <param name="newColumn">Gets assigned to the column index</param>
        public Cell(int newRow, int newColumn)
        {
            this.rowIndex = newRow;
            this.columnIndex = newColumn;
        }

        /// <summary>
        /// Gets a read-only instance for the row index and returns it
        /// </summary>
        public int RowIndex => this.rowIndex;

        /// <summary>
        /// Gets a read-only instance of the column index and returns it
        /// </summary>
        public int ColumnIndex => this.columnIndex;

        /// <summary>
        /// Gets or sets the text variable
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.OnPropertyChanged("Text");
                }
            }
        }

        /// <summary>
        /// Gets the value of the cell
        /// </summary>
        public string Value
        {
            get { return this.value; }
        }

        public uint BGColor
        {
            get
            {
                return this.color;
            }

            set
            {
                if (value != this.color)
                {
                    this.color = value;
                    this.OnPropertyChanged("BGColor");
                }
            }
        }

        /// <summary>
        /// Followed the MSDN documentation for implementing this function
        /// https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/how-to-implement-property-change-notification
        /// </summary>
        /// <param name="name">Acts as the string for the change</param>
        protected void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Followed the MSDN documentation to implement the property changer
        /// https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/how-to-implement-property-change-notification
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
