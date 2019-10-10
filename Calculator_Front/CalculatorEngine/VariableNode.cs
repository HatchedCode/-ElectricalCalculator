// <copyright file="VariableNode.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorEngine
{
    using System.Collections.Generic;

    /// <summary>
    /// The variable node
    /// </summary>
    internal class VariableNode : ExpressionNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// The variable node setter
        /// </summary>
        /// <param name="variableExpression">The expression being used</param>
        public VariableNode(string variableExpression)
        {
            this.Name = variableExpression;
        }

        /// <summary>
        /// Gets or sets the dictionary
        /// </summary>
        public Dictionary<string, double> ReferencetoVariables
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Evaluates the variable
        /// </summary>
        /// <returns>The evaluation</returns>
        public override double Evaluate()
        {
            return this.ReferencetoVariables[this.Name];
        }
    }
}
