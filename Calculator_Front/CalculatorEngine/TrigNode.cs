using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEngine
{
    internal abstract class TrigNode : ExpressionNode
    {
        /// <summary>
        /// 
        /// </summary>
        private char angularmeasurement;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrigNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public TrigNode(double value, char measurement)
        {
            this.Value = value;
            this.angularmeasurement = measurement;
        }

        /// <summary>
        /// Gets and sets the mesurement for the trig function
        /// </summary>
        public char AngleMeasurement
        {
            get { return this.angularmeasurement; }
            set
            {
                this.angularmeasurement = value;
            }
        }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Expression
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Expression
        /// </summary>
        internal double ConvertToDegree()
        {
            return (Math.PI / 180) * this.Value;
        }
    }
}
