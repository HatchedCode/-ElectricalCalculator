using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace CalculatorEngineTests.OperatorNodeTests
{
    [TestClass]
    public class TestMod
    {
        ModNode tModNode;

        [TestMethod]
        public void ModingTwoIntegers()
        {
            this.tModNode = new ModNode();

            ExpressionNode newLeft = new ConstantNode(4);
            ExpressionNode newRight = new ConstantNode(20);

            this.tModNode.Left = newLeft;
            this.tModNode.Right = newRight;

            Assert.AreEqual(this.tModNode.Evaluate(), 0);
        }

        [TestMethod]
        public void ModingTwoFloats()
        {
            this.tModNode = new ModNode();

            ExpressionNode newLeft = new ConstantNode(4.1);
            ExpressionNode newRight = new ConstantNode(72.5);

            this.tModNode.Left = newLeft;
            this.tModNode.Right = newRight;

            Assert.AreEqual(this.tModNode.Evaluate(), 2.800000000000006);
        }

        [TestMethod]
        public void ModingNegative()
        {
            this.tModNode = new ModNode();

            ExpressionNode newLeft = new ConstantNode(3);
            ExpressionNode newRight = new ConstantNode(-21);

            this.tModNode.Left = newLeft;
            this.tModNode.Right = newRight;

            Assert.AreEqual(this.tModNode.Evaluate(), 0);
        }

        [TestMethod]
        public void ModingTwoNegatives()
        {
            this.tModNode = new ModNode();

            ExpressionNode newLeft = new ConstantNode(-9);
            ExpressionNode newRight = new ConstantNode(-75);

            this.tModNode.Left = newLeft;
            this.tModNode.Right = newRight;

            Assert.AreEqual(this.tModNode.Evaluate(), -3);
        }

        //[TestMethod]
        //public void ModingByZero()
        //{
        //    this.tModNode = new ModNode();

        //    ExpressionNode newLeft = new ConstantNode(0);
        //    ExpressionNode newRight = new ConstantNode(81);

        //    this.tModNode.Left = newLeft;
        //    this.tModNode.Right = newRight;

        //    Assert.AreEqual(this.tModNode.Evaluate(), 81);
        //}
    }
}
