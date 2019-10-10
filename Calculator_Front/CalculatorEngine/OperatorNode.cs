// <copyright file="OperatorNode.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorEngine
{
    /// <summary>
    /// The operator node
    /// </summary>
    internal abstract class OperatorNode : ExpressionNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// Sets the left and right to null
        /// </summary>
        public OperatorNode()
        {
            this.Left = this.Right = null;
        }

        /// <summary>
        /// Sets the value for the associativity
        /// </summary>
        public enum Associative
        {
            Left, Right
        }

        /// <summary>
        /// Gets or sets the left side of the expression
        /// </summary>
        public ExpressionNode Left { get; set; }

        /// <summary>
        /// Gets or sets the right side of the expression
        /// </summary>
        public ExpressionNode Right { get; set; }
    }
}
