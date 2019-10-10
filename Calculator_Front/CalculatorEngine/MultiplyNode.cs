// <copyright file="MultiplyNode.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorEngine
{
    /// <summary>
    /// In charge of multiplying
    /// </summary>
    internal class MultiplyNode : OperatorNode
    {
        /// <summary>
        /// Gets the associativity
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Gets the precedence
        /// </summary>
        public static ushort Precedence => 12;

        /// <summary>
        /// Gets the operator
        /// </summary>
        public static char Operator => '*';

        /// <summary>
        /// Evaluates the left and right
        /// </summary>
        /// <returns>The evaluation</returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() * this.Right.Evaluate();
        }
    }
}
