using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    internal abstract class TrigNode : ExpressionNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrigNode"/> class.
        /// Sets the constant value
        /// </summary>
        /// <param name="value">The constant value</param>
        public TrigNode(double value)
        {
            this.Value = value;
        }


        public enum AngularMeasurement
        {
            Deg, Rad
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
            return (this.Value * 180) / Math.PI;
        }

    }
}
