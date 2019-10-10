// <copyright file="DivideNode.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorEngine
{
    using System;

    /// <summary>
    /// Contains all the content needed to divide
    /// </summary>
    internal class DivideNode : OperatorNode
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
        public static char Operator => '/';

        /// <summary>
        /// Evaluates the left and right
        /// </summary>
        /// <returns>Returns the evaluation</returns>
        public override double Evaluate()
        {
            try
            {
                return this.Right.Evaluate() / this.Left.Evaluate();
            }
            catch (DivideByZeroException)
            {
            }

            return this.Right.Evaluate() / this.Left.Evaluate();
        }
    }
}
