using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEngine
{
    /// <summary>
    /// Used for modulo
    /// </summary>
    internal class ModNode : OperatorNode
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
        public static char Operator => '%';

        /// <summary>
        /// Evaluates the left and right
        /// </summary>
        /// <returns>The evaluation</returns>
        public override double Evaluate()
        {
            return this.Right.Evaluate() % this.Left.Evaluate();
        }
    }
}

