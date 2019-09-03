// <copyright file="OpenParanthesis.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    internal class OpenParanthesis : OperatorNode
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
        public static char Operator => '(';

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
