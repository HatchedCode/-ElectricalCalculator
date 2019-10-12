using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace CalculatorEngineTests.OperatorNodeTests
{
    [TestClass]
    public class TestMultiply
    {
        MultiplyNode tMultiplyNode;

        [TestMethod]
        public void MultiplyingTwoIntegers()
        {
            this.tMultiplyNode = new MultiplyNode();

            ExpressionNode newLeft = new ConstantNode(12);
            ExpressionNode newRight = new ConstantNode(12);

            this.tMultiplyNode.Left = newLeft;
            this.tMultiplyNode.Right = newRight;

            Assert.AreEqual(this.tMultiplyNode.Evaluate(), 144);
        }

        [TestMethod]
        public void MultiplyingTwoFloats()
        {
            this.tMultiplyNode = new MultiplyNode();

            ExpressionNode newLeft = new ConstantNode(17.2);
            ExpressionNode newRight = new ConstantNode(5.8);

            this.tMultiplyNode.Left = newLeft;
            this.tMultiplyNode.Right = newRight;

            Assert.AreEqual(this.tMultiplyNode.Evaluate(), 99.759999999999991);
        }

        [TestMethod]
        public void MultiplyingNegative()
        {
            this.tMultiplyNode = new MultiplyNode();

            ExpressionNode newLeft = new ConstantNode(-19);
            ExpressionNode newRight = new ConstantNode(12);

            this.tMultiplyNode.Left = newLeft;
            this.tMultiplyNode.Right = newRight;

            Assert.AreEqual(this.tMultiplyNode.Evaluate(), -228);
        }

        [TestMethod]
        public void MultiplyingTwoNegatives()
        {
            this.tMultiplyNode = new MultiplyNode();

            ExpressionNode newLeft = new ConstantNode(-34);
            ExpressionNode newRight = new ConstantNode(-18);

            this.tMultiplyNode.Left = newLeft;
            this.tMultiplyNode.Right = newRight;

            Assert.AreEqual(this.tMultiplyNode.Evaluate(), 612);
        }

        [TestMethod]
        public void MultiplyingZero()
        {
            this.tMultiplyNode = new MultiplyNode();

            ExpressionNode newLeft = new ConstantNode(0);
            ExpressionNode newRight = new ConstantNode(12.5);

            this.tMultiplyNode.Left = newLeft;
            this.tMultiplyNode.Right = newRight;

            Assert.AreEqual(this.tMultiplyNode.Evaluate(), 0);
        }
    }
}
