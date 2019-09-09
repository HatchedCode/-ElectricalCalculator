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
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public SineNode(double value) : base(value)
        {

        }

        /// <summary>
        /// Gets and sets the mesurement for the trig function
        /// </summary>
        public AngularMeasurement angularMeasurement
        {
            get { return angularMeasurement; }
            set
            {
                this.angularMeasurement = value;
            }
        }

        /// <summary>
        /// Evaluates using the built in Sine function.
        /// </summary>
        /// <returns>Returns the evaluation</returns>
        public override double Evaluate()
        {
            return this.angularMeasurement == AngularMeasurement.Rad ? Math.Sin(this.Value): Math.Sin(ConvertToDegree());
        }

    }
}
