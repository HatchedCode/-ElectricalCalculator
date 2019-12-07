using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using System.Collections.Generic;

namespace CalculatorEngineTests
{
    [TestClass]
    public class ExpressionTreeFactoryTests
    {
        ExpressionTreeFactory factory;
        double result;
        
        [TestInitialize]
        public void Setup()
        {
            this.factory = new ExpressionTreeFactory();
            this.result = 0;
        }

        [TestMethod]
        public void TestCreateOperatorNode()
        {
            //Arrange
            OperatorNode testNode = new AddNode();

            //Act
            OperatorNode actualResult = this.factory.CreateOperatorNode('+');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());
            //Assert.AreEqual(testNode, actualResult);


            // Testing SineNode

            //Arrange
            testNode = new SubtractNode();

            //Act
            actualResult = this.factory.CreateOperatorNode('-');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());

            // Testing TangentNode
            //Arrange
            testNode = new DivideNode();

            //Act
            actualResult = this.factory.CreateOperatorNode('/');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());

            // Testing CoTangentNode
            //Arrange
            testNode = new MultiplyNode();

            //Act
            actualResult = this.factory.CreateOperatorNode('*');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());


            // Testing SecantNode
            //Arrange
            testNode = new ModNode();

            //Act
            actualResult = this.factory.CreateOperatorNode('%');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());

            // Testing INVALID Operator
            try
            {
                //Act
                actualResult = this.factory.CreateOperatorNode('&');

                Assert.Fail("This is not suppose to happen.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                //Assert
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void TestCreateTrigOperatorNode()
        {
            //Arrange
            TrigNode testNode = new CosineNode(20, 'R');

            //Act
            TrigNode actualResult = this.factory.CreateTrigOperatorNode('c', 20, 'R');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());

            // Testing SineNode

            //Arrange
            testNode = new SineNode(20, 'R');

            //Act
            actualResult = this.factory.CreateTrigOperatorNode('s', 20, 'R');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());

            // Testing TangentNode
            //Arrange
            testNode = new TangentNode(20, 'R');

            //Act
            actualResult = this.factory.CreateTrigOperatorNode('t', 20, 'R');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());

            // Testing CoTangentNode
            //Arrange
            testNode = new CotanNode(20, 'R');

            //Act
            actualResult = this.factory.CreateTrigOperatorNode('T', 20, 'R');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());

            // Testing SecantNode
            //Arrange
            testNode = new SecantNode(20, 'R');

            //Act
            actualResult = this.factory.CreateTrigOperatorNode('C', 20, 'R');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());

            // Testing CoSecantNode
            //Arrange
            testNode = new CosecNode(20, 'R');

            //Act
            actualResult = this.factory.CreateTrigOperatorNode('S', 20, 'R');

            //Assert
            Assert.IsInstanceOfType(actualResult, testNode.GetType());

            // Testing INVALID Operator
            try
            {
                //Act
                actualResult = this.factory.CreateTrigOperatorNode('+',90, 'D' );

                Assert.Fail("This is not suppose to happen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                //Assert
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestAngleMeasurement()
        {
            // Testing if we create the correct angle of measurement for Radians
            //Arrange
            char testNode = 'R';

            //Act
            TrigNode actualResult = this.factory.CreateTrigOperatorNode('c', 20, 'R');

            //Assert
            Assert.AreEqual(testNode, actualResult.AngleMeasurement);


            // Testing if we create the correct angle of measurement for Degree
            //Arrange
            testNode = 'D';

            //Act
            actualResult = this.factory.CreateTrigOperatorNode('c', 20, 'D');

            //Assert
            Assert.AreEqual(testNode, actualResult.AngleMeasurement);


            // Testing if we create the correct angle of measurement for incorrect measurement
            //Arrange
            testNode = 'D';

            //Act
            actualResult = this.factory.CreateTrigOperatorNode('c', 20, 'F');

            //Assert
            Assert.AreNotEqual(testNode, actualResult.AngleMeasurement);

        }


        [TestMethod]
        public void TestIsHigherPrecedence()
        {
            //Check if - has higher precedence than +
            bool expected = true;

            //Act
            bool result = this.factory.IsHigherPrecedence('-', '+');

            //Assert
            Assert.AreEqual(expected, result);


            //Check if * has higher precedence than +
            expected = false;

            //Act
            result = this.factory.IsHigherPrecedence('*', '+');

            //Assert
            Assert.AreEqual(expected, result);


            //Check if % has higher precedence than +
            expected = true;

            //Act
            result = this.factory.IsHigherPrecedence('%', '+');

            //Assert
            Assert.AreEqual(expected, result);


            //Check with incorrect/invalid operator
            try
            {
                //Arrange
                expected = true;

                //Act
                result = this.factory.IsHigherPrecedence('s', '+');

                //Assert
                Assert.Fail("There should not be a valid operator that is supported for the inputted operator.");
            }
            catch(KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestIsHigherPrecedence2()
        {
            // test same precedence 
            bool expected = false;
            bool actual = this.factory.IsHigherPrecedence('+', '+');
            Assert.AreEqual(expected, actual);

            actual = this.factory.IsHigherPrecedence('*', '*');
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestIsValidOperator2()
        {
            // some more test cases
            Assert.AreEqual(expected: false, this.factory.IsValidOperator('\0'));
            Assert.AreEqual(expected: false, this.factory.IsValidOperator(' '));
            Assert.AreEqual(expected: false, this.factory.IsValidOperator('^'));
        }
        [TestMethod]
        public void TestIsValidOperator()
        {
            //Testing addition operator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidOperator('+'));

            //Testing subtraction operator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidOperator('-'));

            //Testing division operator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidOperator('/'));

            //Testing multiplication operator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidOperator('*'));

            //Testing Mod oeprator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidOperator('%'));

            //Testing invalid operator
            //Assert
            Assert.AreEqual(expected: false, this.factory.IsValidOperator('T'));
        }

        [TestMethod]
        public void TestIsValidTrigOperator()
        {
            //Testing sine operator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidTrigOperator('s'));

            //Testing cosine operator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidTrigOperator('c'));

            //Testing tangent operator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidTrigOperator('t'));

            //Testing cosecant operator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidTrigOperator('S'));

            //Testing secant operator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidTrigOperator('C'));

            //Testing cotangent operator
            //Assert
            Assert.AreEqual(expected: true, this.factory.IsValidTrigOperator('T'));

            //Testing invalid operator
            //Assert
            Assert.AreEqual(expected: false, this.factory.IsValidTrigOperator('+'));
        }

        [TestCleanup]
        public void Teardown()
        {
            this.factory = null;
            this.result = 0;
        }
    }
}
