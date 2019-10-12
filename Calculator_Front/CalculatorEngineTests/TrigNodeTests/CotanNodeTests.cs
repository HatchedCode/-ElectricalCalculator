using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;

namespace CalculatorEngineTests.TrigNodeTests
{
    [TestClass]
    public class CotanNodeTests
    {
        CotanNode cotan;
        double result;

        [TestInitialize]
        public void Setup()
        {
            this.cotan = new CotanNode(Math.PI / 2, 'r');
            this.result = 0;
        }


        [TestMethod]
        public void TestEvaluate()
        {
            // Test to check that the cotangent of PI/2 degrees is 0.
            this.result = this.cotan.Evaluate();

            //Assert
            Assert.AreEqual(expected: 0, Math.Round(result));


            /* Test to check that the cotangent of 180 degrees is undefined or negative Infinity */
            //Arrange
            this.cotan.AngleMeasurement = 'd';
            this.cotan.Value = 180;

            //Act
            this.result = this.cotan.Evaluate();

            //Assert
            Assert.AreEqual(expected: double.NegativeInfinity, this.result);


            /* Test to check that the cotangent of PI/4 is 1*/
            //Arrange
            this.cotan.AngleMeasurement = 'r';
            this.cotan.Value = Math.PI / 4;

            //Act
            this.result = this.cotan.Evaluate();

            //Assert
            Assert.AreEqual(expected: 1, Math.Round(this.result));
        }

        [TestCleanup]
        public void Teardown()
        {
            this.cotan = null;
            this.result = 0;
        }
    }
}
