using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using NUnit.Framework;
using Moq;

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


            // Test to check that the sine of 90degrees is 0
            mSineNode.Object.Evaluate();
            


            // Test to check that the sine of 90rad is 0.893996664

            // Test to check that the sine of 0 degrees is 0

            // Test to check that the sine of pi/2 is 1

            // Test to check that the sine of -pi/2 is 1

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
