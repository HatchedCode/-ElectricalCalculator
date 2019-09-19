using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class SecantNode : TrigNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecantNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public SecantNode(double value) : base(value)
        {

        }

        /// <summary>
        /// Gets the name of secant
        /// </summary>
        public static string TrigName => "C";

        /// <summary>
        /// Gets and sets the mesurement for the trig function
        /// </summary>
        public AngularMeasurement AngleMeasurement
        {
            get { return AngleMeasurement; }
            set
            {
                this.AngleMeasurement = value;
            }
        }

        /// <summary>
        /// Evaluates using the built in Sine function.
        /// </summary>
        /// <returns>Returns the evaluation</returns>
        public override double Evaluate()
        {
            return this.AngleMeasurement == AngularMeasurement.Rad ? (1 / Math.Cos(this.Value)) : (1 / Math.Cos(ConvertToDegree()));
        }
    }
}
