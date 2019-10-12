using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using System.Collections.Generic;

namespace CalculatorEngineTests.VariableConstantNodeTests
{
    [TestClass]
    public class VariableNodeTests
    {
        VariableNode varNode;
        Dictionary<string, double> dictionary;
        double result;

        [TestInitialize]
        public void Setup()
        {
            this.varNode = new VariableNode("Hello this is a test");
            this.dictionary = new Dictionary<string, double>() { { "Hello this is a test", 100 }, { "test2", 0 }, { "test3", double.NegativeInfinity } };
            this.result = 0;
            this.varNode.ReferencetoVariables = this.dictionary;
        }

        [TestMethod]
        public void TestEvaluate()
        {
            // Test to make sure that we returned the Name that we set.
            this.result = this.varNode.Evaluate();

            //Assert
            Assert.AreEqual(expected: 100, result);


            /* Test to check that after changing the value of the variable, the evaluate should not be the same as the previous value for the time.*/
            //Arrange
            this.varNode.ReferencetoVariables["Hello this is a test"] = 0;

            //Act
            this.result = this.varNode.Evaluate();

            //Assert
            Assert.AreEqual(expected: 0, result);


            /* Test to check that we return negative infinity*/
            //Arrange
            this.varNode.Name = "test3";

            //Act
            this.result = this.varNode.Evaluate();

            //Assert
            Assert.AreEqual(expected: double.NegativeInfinity, result);
        }

        [TestCleanup]
        public void Teardown()
        {
            this.varNode = null;
            this.result = 0;
        }
    }
}
