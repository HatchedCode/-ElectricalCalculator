using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace CalculatorEngineTests.OperatorNodeTests
{
    [TestClass]
    public class TestSubtract
    {
        SubtractNode tSubtractNode;

        [TestMethod]
        public void SubtractingTwoIntegers()
        {
            this.tSubtractNode = new SubtractNode();

            ExpressionNode newLeft = new ConstantNode(28);
            ExpressionNode newRight = new ConstantNode(128);

            this.tSubtractNode.Left = newLeft;
            this.tSubtractNode.Right = newRight;

            Assert.AreEqual(this.tSubtractNode.Evaluate(), 100);
        }

        [TestMethod]
        public void SubtractingTwoFloats()
        {
            this.tSubtractNode = new SubtractNode();

            ExpressionNode newLeft = new ConstantNode(12.8);
            ExpressionNode newRight = new ConstantNode(52.8);

            this.tSubtractNode.Left = newLeft;
            this.tSubtractNode.Right = newRight;

            Assert.AreEqual(this.tSubtractNode.Evaluate(), 40.0);
        }

        [TestMethod]
        public void SubtractingNegative()
        {
            this.tSubtractNode = new SubtractNode();

            ExpressionNode newLeft = new ConstantNode(-19);
            ExpressionNode newRight = new ConstantNode(12);

            this.tSubtractNode.Left = newLeft;
            this.tSubtractNode.Right = newRight;

            Assert.AreEqual(this.tSubtractNode.Evaluate(), 31);
        }

        [TestMethod]
        public void SubtractingTwoNegatives()
        {
            this.tSubtractNode = new SubtractNode();

            ExpressionNode newLeft = new ConstantNode(-34);
            ExpressionNode newRight = new ConstantNode(-18);

            this.tSubtractNode.Left = newLeft;
            this.tSubtractNode.Right = newRight;

            Assert.AreEqual(this.tSubtractNode.Evaluate(), 16);
        }

        [TestMethod]
        public void SubtractingZero()
        {
            this.tSubtractNode = new SubtractNode();

            ExpressionNode newLeft = new ConstantNode(0);
            ExpressionNode newRight = new ConstantNode(12.5);

            this.tSubtractNode.Left = newLeft;
            this.tSubtractNode.Right = newRight;

            Assert.AreEqual(this.tSubtractNode.Evaluate(), 12.5);
        }
    }
}
