// <copyright file="ClosedParanthesis.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorEngine
{
    internal class ClosedParanthesis : OperatorNode
    {
        /// <summary>
        /// Gets the associativity
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Gets the precedence
        /// </summary>
        public static ushort Precedence => 1;

        /// <summary>
        /// Gets the operator
        /// </summary>
        public static char Operator => ')';

        /// <summary>
        /// Evaluates the left and right
        /// </summary>
        /// <returns>The evaluation</returns>
        public override double Evaluate()
        {
            return 0;
        }
    }
}
