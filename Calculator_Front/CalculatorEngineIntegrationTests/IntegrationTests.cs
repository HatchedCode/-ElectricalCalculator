using CalculatorEngine;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

 
namespace CalculatorEngineIntegrationTests
{
    public class IntegrationTests
    {
        public static double IntegrateEvaluate()
        {
            Mock<IExpressionTree> mTree = new Mock<IExpressionTree>(MockBehavior.Loose);

            //Setup
            mTree.Setup(i => i.Evaluate()).Returns(12);

            mTree.Setup(i => i.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>());

            mTree.Setup(i => i.ExpressionFactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            mTree.Setup(i => i.ExpressionFactory.IsValidOperator(It.IsAny<char>())).Returns(It.IsAny<bool>());

            mTree.Setup(i => i.ExpressionFactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            mTree.Setup(i => i.ExpressionFactory.IsValidTrigOperator(It.IsAny<char>())).Returns(It.IsAny<bool>());

            mTree.Setup(i => i.ExpressionFactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(It.IsAny<bool>);

            mTree.Setup(i => i.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
            mTree.Setup(i => i.Evaluate(It.IsAny<ExpressionNode>())).Returns(12);

            var treeUnderTest = new Evaluator(mTree.Object);

            double results = treeUnderTest.Evaluate();

            return results;
        }

        public static double IntegrateShuntingYard()
        {
            Mock<IExpressionTree> mTree = new Mock<IExpressionTree>(MockBehavior.Loose);

            mTree.SetupGet(content => content.InfixExpression).Returns("5");

            //Setup
            //mTree.Setup(i => i.Evaluate()).Returns(12);

            //mTree.Setup(i => i.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>());


            mTree.Setup(i => i.ExpressionFactory.CreateOperatorNode('+')).Returns(new AddNode());
            mTree.Setup(i => i.ExpressionFactory.IsValidOperator('-')).Returns(false);

            mTree.Setup(i => i.ExpressionFactory.CreateTrigOperatorNode('t', 90, 'D')).Returns(new TangentNode(90, 'D'));
            mTree.Setup(i => i.ExpressionFactory.IsValidTrigOperator('t')).Returns(false);

            mTree.Setup(i => i.ExpressionFactory.IsHigherPrecedence('+', '-')).Returns(false);

            mTree.Setup(i => i.ConstructTree(new List<ExpressionNode>() { new ConstantNode(12)})).Returns(new ConstantNode(12));
            mTree.Setup(i => i.Evaluate(It.IsAny<ExpressionNode>())).Returns(12);

            Evaluator treeUnderTest = new Evaluator(mTree.Object);

            double results = treeUnderTest.Evaluate();
            return results;
        }

        public static double IntegrateConstructTree()
        {
            Mock<IExpressionTree> mTree = new Mock<IExpressionTree>(MockBehavior.Loose);

            mTree.SetupGet(content => content.InfixExpression).Returns("5");

            //Setup
            //mTree.Setup(i => i.Evaluate()).Returns(12);

            //mTree.Setup(i => i.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>());


            mTree.Setup(i => i.ExpressionFactory.CreateOperatorNode('+')).Returns(new AddNode());
            mTree.Setup(i => i.ExpressionFactory.IsValidOperator('-')).Returns(false);

            mTree.Setup(i => i.ExpressionFactory.CreateTrigOperatorNode('t', 90, 'D')).Returns(new TangentNode(90, 'D'));
            mTree.Setup(i => i.ExpressionFactory.IsValidTrigOperator('t')).Returns(false);

            mTree.Setup(i => i.ExpressionFactory.IsHigherPrecedence('+', '-')).Returns(false);

            //mTree.Setup(i => i.ConstructTree(new List<ExpressionNode>() { new ConstantNode(12) })).Returns(new ConstantNode(12));
            mTree.Setup(i => i.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);

            Evaluator treeUnderTest = new Evaluator(mTree.Object);

            double results = treeUnderTest.Evaluate();
            return results;
        }

        public static double IntegrateExpressionEvaluate()
        {
            Mock<IExpressionTree> mTree = new Mock<IExpressionTree>(MockBehavior.Loose);
            mTree.SetupAllProperties();
//            mTree.SetupGet(content => content.InfixExpression).Returns("15");

            //Setup
            //mTree.Setup(i => i.Evaluate()).Returns(12);

            //mTree.Setup(i => i.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>());


            mTree.Setup(i => i.ExpressionFactory.CreateOperatorNode('+')).Returns(new AddNode());
            mTree.Setup(i => i.ExpressionFactory.IsValidOperator('-')).Returns(false);

            mTree.Setup(i => i.ExpressionFactory.CreateTrigOperatorNode('t', 90, 'D')).Returns(new TangentNode(90, 'D'));
            mTree.Setup(i => i.ExpressionFactory.IsValidTrigOperator('t')).Returns(false);

            mTree.Setup(i => i.ExpressionFactory.IsHigherPrecedence('+', '-')).Returns(false);

            //mTree.Setup(i => i.ConstructTree(new List<ExpressionNode>() { new ConstantNode(12) })).Returns(new ConstantNode(12));
            //mTree.Setup(i => i.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);

            /*            Console.WriteLine("mTree expression = {0}", mTree.Object.Evaluate());
                        Console.WriteLine("mTree expression Count = {0}", mTree.Object.ShuntingYardAlgorithm().Count);
                        Console.WriteLine("mTree expression = {0}", mTree.Object.InfixExpression);*/

            mTree.Object.InfixExpression = "0";
            mTree.Object.Root = new ConstantNode(0);

            Evaluator treeUnderTest = new Evaluator(mTree.Object);

            /*            Console.WriteLine("treeUnderTest expression Count = {0}", treeUnderTest.ShuntingYardAlgorithm().Count);
            */

            double results = treeUnderTest.Evaluate();


            Console.WriteLine("current expression = {0}", treeUnderTest.InfixExpression);
            Console.WriteLine("current expression = {0}", mTree.Object.InfixExpression);


            return results;
        }

        public static double IntegrateEvaluateEvaluate()
        {
            ExpressionTree treeUnderTest = new ExpressionTree("35");

            double results = treeUnderTest.Evaluate();

            return results;
        }
    }
  }
