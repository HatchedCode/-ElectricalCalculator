using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace CalculatorEngineTests.OperatorNodeTests
{
    [TestClass]
    public class TestAdd
    {
        AddNode tAddNode;

        [TestMethod]
        public void AddingTwoIntegers()
        {
            Mock<AddNode> obj = new Mock<AddNode>();
            
            
            this.tAddNode = new AddNode();

            ExpressionNode newLeft = new ConstantNode(1972);
            ExpressionNode newRight = new ConstantNode(28);

            obj.Object.Left = newLeft;
            obj.Object.Left = newRight;

            obj.Object.Evaluate();
            obj.Object.Evaluate();
            obj.Object.Evaluate();

            obj.Verify(mock => mock.Evaluate(), Times.Exactly(3));



            this.tAddNode.Left = newLeft;
            this.tAddNode.Right = newRight;

            Assert.AreEqual(this.tAddNode.Evaluate(), 2000);
        }

        [TestMethod]
        public void AddingTwoFloats()
        {
            this.tAddNode = new AddNode();

            ExpressionNode newLeft = new ConstantNode(32.8);
            ExpressionNode newRight = new ConstantNode(12.5);

            this.tAddNode.Left = newLeft;
            this.tAddNode.Right = newRight;

            Assert.AreEqual(this.tAddNode.Evaluate(), 45.3);
        }

        [TestMethod]
        public void AddingNegative()
        {
            this.tAddNode = new AddNode();

            ExpressionNode newLeft = new ConstantNode(-19);
            ExpressionNode newRight = new ConstantNode(12);

            this.tAddNode.Left = newLeft;
            this.tAddNode.Right = newRight;

            Assert.AreEqual(this.tAddNode.Evaluate(), -7);

            this.tAddNode = new AddNode();

            newLeft = new ConstantNode(19);
            newRight = new ConstantNode(-12);

            this.tAddNode.Left = newLeft;
            this.tAddNode.Right = newRight;

            Assert.AreEqual(this.tAddNode.Evaluate(), 7);
        }

        [TestMethod]
        public void AddingTwoNegatives()
        {
            this.tAddNode = new AddNode();

            ExpressionNode newLeft = new ConstantNode(-34);
            ExpressionNode newRight = new ConstantNode(-18);

            this.tAddNode.Left = newLeft;
            this.tAddNode.Right = newRight;

            Assert.AreEqual(this.tAddNode.Evaluate(), -52);
        }

        [TestMethod]
        public void AddingZero()
        {
            this.tAddNode = new AddNode();

            ExpressionNode newLeft = new ConstantNode(0);
            ExpressionNode newRight = new ConstantNode(12.5);

            this.tAddNode.Left = newLeft;
            this.tAddNode.Right = newRight;

            Assert.AreEqual(this.tAddNode.Evaluate(), 12.5);
        }
    }
}
