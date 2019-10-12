using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace CalculatorEngineTests.TrigNodeTests
{
    [TestClass]
    public class SineNodeTests
    {
        SineNode sine;
        double result;

        [TestInitialize]
        public void Setup()
        {
            this.sine = new SineNode(90, 'd');
            this.result = 0;
        }

        [TestMethod]
        public void TestEvaluate()
        {
            // Test to check that the sine of 90degrees is 0
            this.result = this.sine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 1, result);

            /* Test to check that the sine of 90rad is 0.893996664 */

            //Arrange
            this.sine.AngleMeasurement = 'r';

            //Act
            this.result = this.sine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 0.893996664, Math.Round(this.result, 9));

            /* Test to check that the sine of 0 degrees is 0 */

            //Arrange
            this.sine.AngleMeasurement = 'd';
            this.sine.Value = 0;

            //Act
            this.result = this.sine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 0, this.result);


            /* Test to check that the sine of pi/2 is 1 */

            //Arrange
            this.sine.AngleMeasurement = 'r';
            this.sine.Value = Math.PI / 2;

            //Act
            this.result = this.sine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 1, this.result);

            /* Test to check that the sine of -pi/2 is 1 */

            //Arrange
            this.sine.AngleMeasurement = 'r';
            this.sine.Value = -Math.PI / 2;

            //Act
            this.result = this.sine.Evaluate();

            //Assert
            Assert.AreEqual(expected: -1, this.result);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.sine = null;
        }
    }
}
