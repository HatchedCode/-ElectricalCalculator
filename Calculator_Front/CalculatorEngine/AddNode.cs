// <copyright file="AddNode.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    /// <summary>
    /// This class is being used for adding
    /// </summary>
    internal class AddNode : OperatorNode
    {
        /// <summary>
        /// Gets the Associativity
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Gets the Precedence
        /// </summary>
        public static ushort Precedence => 11;

        /// <summary>
        /// Gets the operator
        /// </summary>
        public static char Operator => '+';

        /// <summary>
        /// Evaluates the left and right
        /// </summary>
        /// <returns>Returns the evaluation</returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() + this.Right.Evaluate();
        }
    }
}
