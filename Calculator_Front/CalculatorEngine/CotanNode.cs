using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class CotanNode : TrigNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CotanNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public CotanNode(double value, char measurement) : base(value, measurement)
        {
        }

        /// <summary>
        /// Gets the name of cosine
        /// </summary>
        public static char TrigName => 'T';

        /// <summary>
        /// Evaluates using the built in Sine function.
        /// </summary>
        /// <returns>Returns the evaluation</returns>
        public override double Evaluate()
        {
            return this.AngleMeasurement == 'R' ? (1 / Math.Tan(this.Value)) : Math.Round(1 / Math.Tan(ConvertToDegree()), 4);
        }
    }
}
