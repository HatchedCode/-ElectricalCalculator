using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace CalculatorEngineTests.TrigNodeTests
{
    [TestClass]
    public class SineNodeTest
    {
        SineNode sine;

        [SetUp]
        public void Setup()
        {
            this.sine = new SineNode(90, 'd');
        }

        [TestMethod]
        public void TestEvaluate()
        {
            // Setup
            Mock<SineNode> mSineNode = new Mock<SineNode>(90, 'd');
            double result = 0;

            mSineNode.Setup(mock => mock.Evaluate());

            this.sine = new SineNode(mSineNode.Object);

            // Test to check that the sine of 90degrees is 0
            result = this.sine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 1, result);

            // Test to check that the sine of 90rad is 0.893996664

            //Arrange
            this.sine.AngleMeasurement = 'r';

            //Act
            result = this.sine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 0.893996664, Math.Round(result,9));



            // Test to check that the sine of 0 degrees is 0
            
            //Arrange
            this.sine.AngleMeasurement = 'd';
            this.sine.Value = 0;

            //Act
            result = this.sine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 0, result);


            // Test to check that the sine of pi/2 is 1

            //Arrange
            this.sine.AngleMeasurement = 'r';
            this.sine.Value = Math.PI / 2;

            //Act
            result = this.sine.Evaluate();

            //Assert
            Assert.AreEqual(expected: 1, result);

            // Test to check that the sine of -pi/2 is 1

            //Arrange
            this.sine.AngleMeasurement = 'r';
            this.sine.Value = -Math.PI / 2;

            //Act
            result = this.sine.Evaluate();

            //Assert
            Assert.AreEqual(expected: -1, result);

            //Assert by verification

            //Verify that the number of calls to evaluate is 5
            mSineNode.Verify(mock => mock.Evaluate(), Times.Exactly(5), "The method did not get called 5 times!");   //This is the part I am currently trying to fix. Not getting the right number of calls to the method.
        }

        [TearDown]
        public void Teardown()
        {
            this.sine = null;
        }
    }
}
