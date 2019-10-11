using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEngine
{
    class SecantNode : TrigNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecantNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public SecantNode(double value, char measurement) : base(value, measurement)
        {
        }

        /// <summary>
        /// Gets the name of secant
        /// </summary>
        public static char TrigName => 'C';

        /// <summary>
        /// Evaluates using the built in Sine function.
        /// </summary>
        /// <returns>Returns the evaluation</returns>
        public override double Evaluate()
        {
            return this.AngleMeasurement == 'R' || this.AngleMeasurement == 'r' ? (1 / Math.Cos(this.Value)) : Math.Round((1 / Math.Cos(ConvertToDegree())), 4);
        }
    }
}
