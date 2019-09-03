// <copyright file="ConstantNode.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    /// <summary>
    /// The constant node, mainly numbers
    /// </summary>
    internal class ConstantNode : ExpressionNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public ConstantNode(double value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Evaluates the value
        /// </summary>
        /// <returns>The value</returns>
        public override double Evaluate()
        {
            return this.Value;
        }
    }
}
