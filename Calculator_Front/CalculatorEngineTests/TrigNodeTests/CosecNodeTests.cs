using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;

namespace CalculatorEngineTests.TrigNodeTests
{
    [TestClass]
    public class CosecNodeTests
    {
        CosecNode cosec;
        double result;

        [TestInitialize]
        public void Setup()
        {
            this.cosec = new CosecNode(0, 'd');
            this.result = 0;
        }


        [TestMethod]
        public void TestEvaluate()
        {
            // Test to check that the cosec of 0 degrees is infinity
            this.result = this.cosec.Evaluate();

            //Assert
            Assert.AreEqual(expected: double.PositiveInfinity, result);


            /* Test to check that the cosec of 90rad is 1.11857241 */
            //Arrange
            this.cosec.AngleMeasurement = 'r';
            this.cosec.Value = 90;

            //Act
            this.result = this.cosec.Evaluate();

            //Assert
            Assert.AreEqual(expected: 1.11857241, Math.Round(this.result, 8));


            /* Test to check that the cosec of 45 degrees is 1.414213562 */
            //Arrange
            this.cosec.AngleMeasurement = 'd';
            this.cosec.Value = 45;

            //Act
            this.result = this.cosec.Evaluate();

            //Assert
            Assert.AreEqual(expected: Math.Round(1.414213562, 4), this.result);


            /* Test to check that the cosec of 3PI/4 is -1.414213562 */
            //Arrange
            this.cosec.AngleMeasurement = 'r';
            this.cosec.Value = (5*Math.PI) / 4;

            //Act
            this.result = this.cosec.Evaluate();

            //Assert
            Assert.AreEqual(expected: -1.414213562, Math.Round(this.result,9));


            /* Test to check that the cosec of PI/2 is 1 */
            //Arrange
            this.cosec.AngleMeasurement = 'r';
            this.cosec.Value = Math.PI / 2;

            //Act
            this.result = this.cosec.Evaluate();

            //Assert
            Assert.AreEqual(expected: 1, Math.Round(this.result));
        }

        [TestCleanup]
        public void Teardown()
        {
            this.cosec = null;
            this.result = 0;
        }
    }
}
