// <copyright file="SubtractNode.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    /// <summary>
    /// Used to subtract
    /// </summary>
    internal class SubtractNode : OperatorNode
    {
        /// <summary>
        /// Gets the associativity
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Gets the precedence
        /// </summary>
        public static ushort Precedence => 11;

        /// <summary>
        /// Gets the operator
        /// </summary>
        public static char Operator => '-';

        /// <summary>
        /// Evaluates the left and right
        /// </summary>
        /// <returns>The evaluation</returns>
        public override double Evaluate()
        {
            return this.Right.Evaluate() - this.Left.Evaluate();
        }
    }
}
