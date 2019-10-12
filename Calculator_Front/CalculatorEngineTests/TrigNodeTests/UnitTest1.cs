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
            Mock<SineNode> mSineNode = new Mock<SineNode>();
            mSineNode.Object.AngleMeasurement = 'r';
            mSineNode.Object.Value = 90;
            double result = 0;

            // Test to check that the sine of 90degrees is 0
            result = mSineNode.Object.Evaluate();
            Assert.AreEqual(expected: 1, result);

            // Test to check that the sine of 90rad is 0.893996664
            mSineNode.Object.AngleMeasurement = 'r';
            result = mSineNode.Object.Evaluate();
            Assert.AreEqual(expected: 0.893996664, result);

            // Test to check that the sine of 0 degrees is 0
            mSineNode.Object.AngleMeasurement = 'd';
            mSineNode.Object.Value = 0;
            result = mSineNode.Object.Evaluate();
            Assert.AreEqual(expected: 0, result);

            // Test to check that the sine of pi/2 is 1
            mSineNode.Object.AngleMeasurement = 'r';
            mSineNode.Object.Value = Math.PI / 2;
            result = mSineNode.Object.Evaluate();
            Assert.AreEqual(expected: 1, result);

            // Test to check that the sine of -pi/2 is 1
            mSineNode.Object.AngleMeasurement = 'r';
            mSineNode.Object.Value = -Math.PI / 2;
            result = mSineNode.Object.Evaluate();
            Assert.AreEqual(expected: -1, result);

            //Verify that the number of calls to evaluate is 5
            mSineNode.Verify(mock => mock.Evaluate(), Times.Exactly(5));
        }

        [TearDown]
        public void Teardown()
        {
            this.sine = null;
        }
    }
}
