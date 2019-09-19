using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{

    internal class SineNode : TrigNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SineNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public SineNode(double value, char measurement) : base(value, measurement)
        {
        }

        /// <summary>
        /// Gets the name of sine
        /// </summary>
        public static char TrigName => 's';


        /// <summary>
        /// Evaluates using the built in Sine function.
        /// </summary>
        /// <returns>Returns the evaluation</returns>
        public override double Evaluate()
        {
            return this.AngleMeasurement == 'R' ? Math.Sin(this.Value): Math.Round(Math.Sin(this.ConvertToDegree()), 4);
        }

    }
}
