using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEngine
{
    internal class TangentNode : TrigNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TangentNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public TangentNode(double value, char measurement) : base(value, measurement)
        {
        }

        /// <summary>
        /// Gets the name of tangent
        /// </summary>
        public static char TrigName => 't';

        /// <summary>
        /// Evaluates using the built in Sine function.
        /// </summary>
        /// <returns>Returns the evaluation</returns>
        public override double Evaluate()
        {
            return this.AngleMeasurement == 'R' || this.AngleMeasurement == 'r' ? Math.Tan(this.Value) : Math.Round(Math.Tan(this.ConvertToDegree()), 4);
        }
    }
}
