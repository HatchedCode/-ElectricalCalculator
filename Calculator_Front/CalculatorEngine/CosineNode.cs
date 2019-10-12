using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEngine
{
    internal class CosineNode : TrigNode
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CosineNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public CosineNode(double value, char measurement) : base(value, measurement)
        {
        }

        /// <summary>
        /// Gets the name of cosine
        /// </summary>
        public static char TrigName => 'c';


        /// <summary>
        /// Evaluates using the built in Cosine function.
        /// </summary>
        /// <returns>Returns the evaluation</returns>
        public override double Evaluate()
        {
            return this.AngleMeasurement == 'R' || this.AngleMeasurement == 'r' ? Math.Cos(this.Value) : Math.Round(Math.Cos(this.ConvertToDegree()), 4);
        }
    }
}
