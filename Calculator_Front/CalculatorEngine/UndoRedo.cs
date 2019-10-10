// <copyright file="UndoRedo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorEngine
{
    using System.Collections.Generic;

    /// <summary>
    /// The code needed to redo and undo
    /// </summary>
    public class UndoRedo
    {
        /// <summary>
        /// The redo stack
        /// </summary>
        private Stack<SpreadSheetModifications> redoStack;

        /// <summary>
        /// The undo stack
        /// </summary>
        private Stack<SpreadSheetModifications> undoStack;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedo"/> class.
        /// The class constructor
        /// </summary>
        public UndoRedo()
        {
            this.Reset();
        }

        /// <summary>
        /// Gets the number of items inside the redo stack
        /// </summary>
        public int RedoCount
        {
            get { return this.redoStack.Count; }
        }

        /// <summary>
        /// Gets the number of items inside the undo stack
        /// </summary>
        public int UndoCount
        {
            get { return this.undoStack.Count; }
        }

        /// <summary>
        /// Resets the stacks to empty
        /// </summary>
        public void Reset()
        {
            this.redoStack = new Stack<SpreadSheetModifications>();
            this.undoStack = new Stack<SpreadSheetModifications>();
        }

        /// <summary>
        /// Adds a new modification to the stack and clears the redo stack
        /// </summary>
        /// <param name="myUndos">The new object</param>
        public void AddUndo(SpreadSheetModifications myUndos)
        {
            this.undoStack.Push(myUndos);
            this.redoStack.Clear();
        }

        /// <summary>
        /// Executes the stack redo
        /// </summary>
        public void Redo()
        {
            if (this.RedoCount > 0)
            {
                SpreadSheetModifications cmd = this.redoStack.Pop();
                this.undoStack.Push(cmd.Execute());
            }
        }

        /// <summary>
        /// Executes the stack undo
        /// </summary>
        public void Undo()
        {
            if (this.UndoCount > 0)
            {
                SpreadSheetModifications cmd = this.undoStack.Pop();
                this.redoStack.Push(cmd.Execute());
            }
        }
    }
}
