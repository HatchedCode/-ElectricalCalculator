// <copyright file="ExpressionNode.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    /// <summary>
    /// The main expression node
    /// </summary>
    internal abstract class ExpressionNode
    {
        /// <summary>
        /// Forces for evaluations
        /// </summary>
        /// <returns>A number</returns>
        public abstract double Evaluate();
    }
}
