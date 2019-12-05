// <copyright file="ExpressionNode.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorEngine
{
    /// <summary>
    /// The main expression node
    /// </summary>
    public abstract class ExpressionNode
    {
        /// <summary>
        /// Forces for evaluations
        /// </summary>
        /// <returns>A number</returns>
        public abstract double Evaluate();
    }
}
