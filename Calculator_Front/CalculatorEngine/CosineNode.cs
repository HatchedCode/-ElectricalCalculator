using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class CosineNode : TrigNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CosineNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public CosineNode(double value) : base(value)
        {

        }

        /// <summary>
        /// Gets the name of cosine
        /// </summary>
        public static string TrigName => "cos";

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
            return this.AngleMeasurement == AngularMeasurement.Rad ? Math.Cos(this.Value) : Math.Cos(ConvertToDegree());
        }
    }
}
