using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;

namespace CalculatorEngineTests.TrigNodeTests
{
    [TestClass]
    public class CosineNodeTests
    {
        CosineNode cosine;
        double result;

        [TestInitialize]
        public void Setup()
        {
            this.cosine = new CosineNode(0, 'd');
            this.result = 0;
        }

        [TestMethod]
        public void TestEvaluate()
        {
            // Test to check that the cosine of 0 degrees is 1
            this.result = this.cosine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 1, result);


            /* Test to check that the cosine of 90rad is -0.448073616 */
            //Arrange
            this.cosine.AngleMeasurement = 'r';
            this.cosine.Value = 90;

            //Act
            this.result = this.cosine.Evaluate();

            //Assert
            Assert.AreEqual(expected: -0.448073616, Math.Round(this.result, 9));


            /* Test to check that the cosine of 90 degrees is 0 */
            //Arrange
            this.cosine.AngleMeasurement = 'd';

            //Act
            this.result = this.cosine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 0, this.result);


            /* Test to check that the cosine of pi/2 is 0 */
            //Arrange
            this.cosine.AngleMeasurement = 'r';
            this.cosine.Value = Math.PI / 2;

            //Act
            this.result = this.cosine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 0, Math.Round(this.result));


            /* Test to check that the cosine of -pi/2 is 0 */
            //Arrange
            this.cosine.AngleMeasurement = 'r';
            this.cosine.Value = -Math.PI / 2;

            //Act
            this.result = this.cosine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 0, Math.Round(this.result));


            /* Test to check that the cosine of pi is -1 */
            //Arrange
            this.cosine.AngleMeasurement = 'r';
            this.cosine.Value = -Math.PI;

            //Act
            this.result = this.cosine.Evaluate();

            //Assert
            Assert.AreEqual(expected: -1, Math.Round(this.result));
        }

        [TestCleanup]
        public void Teardown()
        {
            this.cosine = null;
            this.result = 0;
        }
    }
}
