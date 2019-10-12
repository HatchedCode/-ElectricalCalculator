using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;

namespace CalculatorEngineTests.TrigNodeTests
{
    [TestClass]
    public class SecantNodeTests
    {
        SecantNode sec;
        double result;

        [TestInitialize]
        public void Setup()
        {
            this.sec = new SecantNode(0, 'd');
            this.result = 0;
        }


        [TestMethod]
        public void TestEvaluate()
        {
            // Test to check that the sec of 0 degrees is 1
            this.result = this.sec.Evaluate();

            //Assert
            Assert.AreEqual(expected: 1, result);


            /* Test to check that the sec of 90rad is -2.23177613 */
            //Arrange
            this.sec.AngleMeasurement = 'r';
            this.sec.Value = 90;

            //Act
            this.result = this.sec.Evaluate();

            //Assert
            Assert.AreEqual(expected: -2.23177613, Math.Round(this.result, 8));


            /* Test to check that the sec of 45 degrees is 1.414213562 */
            //Arrange
            this.sec.AngleMeasurement = 'd';
            this.sec.Value = 45;

            //Act
            this.result = this.sec.Evaluate();

            //Assert
            Assert.AreEqual(expected: Math.Round(1.414213562, 4), this.result);


            /* Test to check that the sec of 3PI/4 is -1.414213562 */
            //Arrange
            this.sec.AngleMeasurement = 'r';
            this.sec.Value = (5 * Math.PI) / 4;

            //Act
            this.result = this.sec.Evaluate();

            //Assert
            Assert.AreEqual(expected: -1.414213562, Math.Round(this.result, 9));


            /* Test to check that the sec of 90 degrees is infinity*/
            //Arrange
            this.sec.AngleMeasurement = 'd';
            this.sec.Value = 90;

            //Act
            this.result = this.sec.Evaluate();

            //Assert
            Assert.AreEqual(expected: double.PositiveInfinity, this.result);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.sec = null;
            this.result = 0;
        }
    }
}
