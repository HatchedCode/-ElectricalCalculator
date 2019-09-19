using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class TangentNode : TrigNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TangentNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public TangentNode(double value) : base(value)
        {

        }

        /// <summary>
        /// Gets the name of tangent
        /// </summary>
        public static string TrigName => "t";

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
            return this.AngleMeasurement == AngularMeasurement.Rad ? Math.Tan(this.Value) : Math. Tan(ConvertToDegree());
        }
    }
}
