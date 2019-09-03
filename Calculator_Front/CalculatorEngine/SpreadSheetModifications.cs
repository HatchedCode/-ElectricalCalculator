// <copyright file="SpreadSheetModifications.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System.Collections.Generic;

    /// <summary>
    /// Executes the modifications
    /// </summary>
    public class SpreadSheetModifications
    {
        /// <summary>
        /// The list of modifications made
        /// </summary>
        private List<ICommand> modifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadSheetModifications"/> class.
        /// The constructor for the modifcations
        /// </summary>
        /// <param name="modify">The new list of modifications</param>
        public SpreadSheetModifications(List<ICommand> modify)
        {
            this.modifications = modify;
        }

        /// <summary>
        /// Runs the executions
        /// </summary>
        /// <returns>A modifcation object</returns>
        public SpreadSheetModifications Execute()
        {
            List<ICommand> modList = new List<ICommand>();

            if (this.modifications.Count != 0)
            {
                foreach (ICommand mod in this.modifications)
                {
                    modList.Add(mod.Execute());
                }
            }

            return new SpreadSheetModifications(modList);
        }
    }
}
