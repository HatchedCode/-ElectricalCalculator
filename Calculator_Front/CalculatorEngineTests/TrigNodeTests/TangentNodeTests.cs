using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;

namespace CalculatorEngineTests.TrigNodeTests
{
    [TestClass]
    public class TangentNodeTests
    {
        TangentNode tan;
        double result;

        [TestInitialize]
        public void Setup()
        {
            this.tan = new TangentNode(Math.PI/2, 'r');
            this.result = 0;
        }


        [TestMethod]
        public void TestEvaluate()
        {
            // Test to check that the tangent of PI/2 degrees is Undefined.
            this.result = this.tan.Evaluate();

            //Assert
            Assert.AreEqual(expected: Math.Tan(Math.PI/2), result);


            /* Test to check that the tangent of 180 degrees is 0 */
            //Arrange
            this.tan.AngleMeasurement = 'd';
            this.tan.Value = 180;

            //Act
            this.result = this.tan.Evaluate();

            //Assert
            Assert.AreEqual(expected: 0, this.result);


            /* Test to check that the tangent of PI/4 is 1*/
            //Arrange
            this.tan.AngleMeasurement = 'r';
            this.tan.Value = Math.PI / 4;

            //Act
            this.result = this.tan.Evaluate();

            //Assert
            Assert.AreEqual(expected: 1, Math.Round(this.result));
        }

        [TestCleanup]
        public void Teardown()
        {
            this.tan = null;
            this.result = 0;
        }
    }
}
