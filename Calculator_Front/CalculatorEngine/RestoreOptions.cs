// <copyright file="RestoreOptions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    /// <summary>
    /// Restores the spreadsheet color
    /// </summary>
    public class RestoreColor : ICommand
    {
        /// <summary>
        /// The cell
        /// </summary>
        private Cell currentCell;

        /// <summary>
        /// The number of the background
        /// </summary>
        private uint backgroundColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestoreColor"/> class.
        /// Constructor for restoring the color
        /// </summary>
        /// <param name="newCell">The previous cell</param>
        /// <param name="newColor">The previous text</param>
        public RestoreColor(Cell newCell, uint newColor)
        {
            this.currentCell = newCell;
            this.backgroundColor = newColor;
        }

        /// <summary>
        /// Executes the changes needed
        /// </summary>
        /// <returns>A command object</returns>
        public ICommand Execute()
        {
            uint currentColor = this.currentCell.BGColor;
            this.currentCell.BGColor = this.backgroundColor;
            return new RestoreColor(this.currentCell, currentColor);
        }
    }

    /// <summary>
    /// Restores the text of the spreadsheet
    /// </summary>
    public class RestoreText : ICommand
    {
        /// <summary>
        /// The cell
        /// </summary>
        private Cell currentCell;

        /// <summary>
        /// The cells text
        /// </summary>
        private string cellText;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestoreText"/> class.
        /// Constructor for restoring the text
        /// </summary>
        /// <param name="newCell">The new cell</param>
        /// <param name="newText">The new text</param>
        public RestoreText(Cell newCell, string newText)
        {
            this.currentCell = newCell;
            this.cellText = newText;
        }

        /// <summary>
        /// Eexecute the changes needed
        /// </summary>
        /// <returns>A command object</returns>
        public ICommand Execute()
        {
            string currentText = this.currentCell.Text;
            this.currentCell.Text = this.cellText;
            return new RestoreText(this.currentCell, currentText);
        }
    }
}
