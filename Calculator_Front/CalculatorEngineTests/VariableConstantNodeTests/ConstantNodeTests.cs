using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;

namespace CalculatorEngineTests.VariableConstantNodeTests
{
    [TestClass]
    public class ConstantNodeTests
    {
        ConstantNode constNode;
        double result;

        [TestInitialize]
        public void Setup()
        {
            this.constNode = new ConstantNode(10);
            this.result = 0;
        }

        [TestMethod]
        public void TestEvaluate()
        {
            // Test to make sure that we returnt the value that we set.
            this.result = this.constNode.Evaluate();

            //Assert
            Assert.AreEqual(expected: 10, result);


            /* Test to check that we return infinity*/
            //Arrange
            this.constNode.Value = double.NegativeInfinity;

            //Act
            this.result = this.constNode.Evaluate();

            //Assert
            Assert.AreEqual(expected: double.NegativeInfinity, result);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.constNode = null;
            this.result = 0;
        }
    }
}
