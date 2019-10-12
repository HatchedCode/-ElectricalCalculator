using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace CalculatorEngineTests.OperatorNodeTests
{
    [TestClass]
    public class TestDivide
    {
        DivideNode tDivideNode;

        [TestMethod]
        public void DividingTwoIntegers()
        {
            this.tDivideNode = new DivideNode();

            ExpressionNode newLeft = new ConstantNode(3);
            ExpressionNode newRight = new ConstantNode(12);

            this.tDivideNode.Left = newLeft;
            this.tDivideNode.Right = newRight;

            Assert.AreEqual(this.tDivideNode.Evaluate(), 4);
        }

        [TestMethod]
        public void DividingTwoFloats()
        {
            this.tDivideNode = new DivideNode();

            ExpressionNode newLeft = new ConstantNode(5.1);
            ExpressionNode newRight = new ConstantNode(20.4);

            this.tDivideNode.Left = newLeft;
            this.tDivideNode.Right = newRight;

            Assert.AreEqual(this.tDivideNode.Evaluate(), 4);
        }

        [TestMethod]
        public void DividingNegative()
        {
            this.tDivideNode = new DivideNode();

            ExpressionNode newLeft = new ConstantNode(9);
            ExpressionNode newRight = new ConstantNode(-36);

            this.tDivideNode.Left = newLeft;
            this.tDivideNode.Right = newRight;

            Assert.AreEqual(this.tDivideNode.Evaluate(), -4);
        }

        [TestMethod]
        public void DividingTwoNegatives()
        {
            this.tDivideNode = new DivideNode();

            ExpressionNode newLeft = new ConstantNode(-4);
            ExpressionNode newRight = new ConstantNode(-36);

            this.tDivideNode.Left = newLeft;
            this.tDivideNode.Right = newRight;

            Assert.AreEqual(this.tDivideNode.Evaluate(), 9);
        }

        //[testmethod]
        //public void dividingbyzero()
        //{
        //    this.tdividenode = new dividenode();

        //    expressionnode newleft = new constantnode(0);
        //    expressionnode newright = new constantnode(12);

        //    this.tdividenode.left = newleft;
        //    this.tdividenode.right = newright;

        //    assert.equals(this.tdividenode.evaluate(), dividebyzeroexception);
        //}
    }
}
