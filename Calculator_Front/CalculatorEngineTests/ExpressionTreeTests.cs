using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;

namespace CalculatorEngineTests
{
    [TestClass]
    public class ExpressionTreeTests
    {
       
        

        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestPrivateEvaluate()
        {
            ExpressionTree tree = new ExpressionTree("20+1");
            OperatorNode head = new AddNode();
            head.Left = new ConstantNode(20);
            head.Right = new ConstantNode(1);
            PrivateObject t = new PrivateObject(tree);

            var ret = t.Invoke("Evaluate", head);
            Assert.AreEqual(ret, 21);

        }

        [TestMethod]
        public void TestPublicEvaluate()
        {
            ExpressionTree tree = new ExpressionTree("20+1");

            Assert.AreEqual(tree.Evaluate(), 21);

        }

        [TestMethod]
        public void TestConstructTree()
        {
            ExpressionTree tree = new ExpressionTree("20+1");
            PrivateObject t = new PrivateObject(tree);
            System.Collections.Generic.List<ExpressionNode> postfixList = new System.Collections.Generic.List<ExpressionNode>();
            postfixList.Add(new ConstantNode(20));
            postfixList.Add(new ConstantNode(1));
            postfixList.Add(new AddNode());

            Object ret = t.Invoke("ConstructTree", postfixList);
            ExpressionNode head = (ExpressionNode)ret;

            //checks if head is OperatorNode
            Assert.IsTrue(head is OperatorNode);
            OperatorNode temp = (OperatorNode)head;


            //checks to see if Left is Constant Node
            Assert.IsTrue(temp.Left is ConstantNode);
            ConstantNode Left = (ConstantNode)temp.Left;
            //checks if Left is 20
            Assert.AreEqual(Left.Value, 1);
            
            //checks if Right is a constant Node
            Assert.IsTrue(temp.Right is ConstantNode);
            ConstantNode Right = (ConstantNode)temp.Right;
            //checks if Right is 1
            Assert.AreEqual(Right.Value, 20);

        }

        [TestMethod]
        public void TestShuntingYardAlgorithm()
        {
            ExpressionTree tree = new ExpressionTree("20+1");

            PrivateObject privateTree = new PrivateObject(tree);

            object ret = privateTree.Invoke("ShuntingYardAlgorithm");
            System.Collections.Generic.List<ExpressionNode> postfixList = (System.Collections.Generic.List<ExpressionNode>)ret;
            Assert.IsTrue(postfixList[0] is ConstantNode);
            ConstantNode temp = (ConstantNode)postfixList[0];
            Assert.AreEqual(20, temp.Value);

            Assert.IsTrue(postfixList[1] is ConstantNode);
             temp = (ConstantNode)postfixList[1];
            Assert.AreEqual(1, temp.Value);
            Assert.IsTrue(postfixList[2] is AddNode);
        }


    }
}
