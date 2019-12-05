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
            //Mock object
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            mTree.Setup(_ => _.Evaluate()).Returns(12);

            mTree.Setup(_ => _.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>());

            mTree.Setup(_ => _.Expressiontreefactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            mTree.Setup(_ => _.Expressiontreefactory.IsValidOperator(It.IsAny<char>())).Returns(It.IsAny<bool>());

            mTree.Setup(_ => _.Expressiontreefactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            mTree.Setup(_ => _.Expressiontreefactory.IsValidTrigOperator(It.IsAny<char>())).Returns(It.IsAny<bool>());

            mTree.Setup(_ => _.Expressiontreefactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(It.IsAny<bool>);

            mTree.Setup(_ => _.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
            mTree.Setup(_ => _.Evaluate(It.IsAny<ExpressionNode>())).Returns(12);

            double result = mTree.Object.Evaluate();

            return result;
        }

        public static double IntegrateShuntingYard()
        {
            //Mock object
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            //mTree.Setup(_ => _.Evaluate()).Returns(12);

            //mTree.Setup(_ => _.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>());

            mTree.Setup(_ => _.Expressiontreefactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            mTree.Setup(_ => _.Expressiontreefactory.IsValidOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            mTree.Setup(_ => _.Expressiontreefactory.IsValidTrigOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
            mTree.Setup(_ => _.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);
            mTree.Setup(_ => _.Root.Evaluate()).Returns(5);

            double result = mTree.Object.Evaluate();

            return result;
        }


        public static double IntegrateConstructTree()
        {
            //Mock object
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            //mTree.Setup(_ => _.Evaluate()).Returns(12);

            //mTree.Setup(_ => _.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>() { new ConstantNode(5) });

            mTree.Setup(_ => _.Expressiontreefactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            mTree.Setup(_ => _.Expressiontreefactory.IsValidOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            mTree.Setup(_ => _.Expressiontreefactory.IsValidTrigOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(false);

//            mTree.Setup(_ => _.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
            mTree.Setup(_ => _.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);
            mTree.Setup(_ => _.Root.Evaluate()).Returns(5);

            double result = mTree.Object.Evaluate();

            return result;
        }

        public static double IntegrateExpressionEvaluate()
        {
            //Mock object
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            //mTree.Setup(_ => _.Evaluate()).Returns(12);

            //mTree.Setup(_ => _.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>() { new ConstantNode(5) });

            mTree.Setup(_ => _.Expressiontreefactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            mTree.Setup(_ => _.Expressiontreefactory.IsValidOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            mTree.Setup(_ => _.Expressiontreefactory.IsValidTrigOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(false);

            //            mTree.Setup(_ => _.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
//            mTree.Setup(_ => _.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);
            mTree.Setup(_ => _.Root.Evaluate()).Returns(5);

            double result = mTree.Object.Evaluate();

            return result;
        }

        public static double IntegrateIsValidTrigOperator()
        {
            //Mock object
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            //mTree.Setup(_ => _.Evaluate()).Returns(12);

            //mTree.Setup(_ => _.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>() { new ConstantNode(5) });

            mTree.Setup(_ => _.Expressiontreefactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            mTree.Setup(_ => _.Expressiontreefactory.IsValidOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            //mTree.Setup(_ => _.Expressiontreefactory.IsValidTrigOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(false);

            //            mTree.Setup(_ => _.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
            //mTree.Setup(_ => _.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);
            mTree.Setup(_ => _.Root.Evaluate()).Returns(5);

            double result = mTree.Object.Evaluate();

            return result;
        }


        public static double IntegrateCreateTrigOperatorNode()
        {
            //Mock object
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            //mTree.Setup(_ => _.Evaluate()).Returns(12);

            //mTree.Setup(_ => _.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>() { new ConstantNode(5) });

            mTree.Setup(_ => _.Expressiontreefactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            mTree.Setup(_ => _.Expressiontreefactory.IsValidOperator(It.IsAny<char>())).Returns(false);

           // mTree.Setup(_ => _.Expressiontreefactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            //mTree.Setup(_ => _.Expressiontreefactory.IsValidTrigOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(false);

            //            mTree.Setup(_ => _.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
            //mTree.Setup(_ => _.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);
            mTree.Setup(_ => _.Root.Evaluate()).Returns(5);

            double result = mTree.Object.Evaluate();

            return result;
        }


        public static double IntegrateIsValidOperator()
        {
            //Mock object
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            //mTree.Setup(_ => _.Evaluate()).Returns(12);

            //mTree.Setup(_ => _.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>() { new ConstantNode(5) });

            mTree.Setup(_ => _.Expressiontreefactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            //mTree.Setup(_ => _.Expressiontreefactory.IsValidOperator(It.IsAny<char>())).Returns(false);

            //mTree.Setup(_ => _.Expressiontreefactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            //mTree.Setup(_ => _.Expressiontreefactory.IsValidTrigOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(false);

            //            mTree.Setup(_ => _.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
            //mTree.Setup(_ => _.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);
            mTree.Setup(_ => _.Root.Evaluate()).Returns(5);

            double result = mTree.Object.Evaluate();

            return result;
        }


        public static double IntegrateCreateOperatorNode()
        {
            //Mock object
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            //mTree.Setup(_ => _.Evaluate()).Returns(12);

            //mTree.Setup(_ => _.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>() { new ConstantNode(5) });

            //mTree.Setup(_ => _.Expressiontreefactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            //mTree.Setup(_ => _.Expressiontreefactory.IsValidOperator(It.IsAny<char>())).Returns(false);

            //mTree.Setup(_ => _.Expressiontreefactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            //mTree.Setup(_ => _.Expressiontreefactory.IsValidTrigOperator(It.IsAny<char>())).Returns(false);

            mTree.Setup(_ => _.Expressiontreefactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(false);

            //            mTree.Setup(_ => _.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
            //mTree.Setup(_ => _.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);
            mTree.Setup(_ => _.Root.Evaluate()).Returns(5);

            double result = mTree.Object.Evaluate();

            return result;
        }

        public static double IntegrateIsHigherPrecedence()
        {
            //Mock object
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            //mTree.Setup(_ => _.Evaluate()).Returns(12);

            //mTree.Setup(_ => _.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>() { new ConstantNode(5) });

            //mTree.Setup(_ => _.Expressiontreefactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            //mTree.Setup(_ => _.Expressiontreefactory.IsValidOperator(It.IsAny<char>())).Returns(false);

            //mTree.Setup(_ => _.Expressiontreefactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            //mTree.Setup(_ => _.Expressiontreefactory.IsValidTrigOperator(It.IsAny<char>())).Returns(false);

            //mTree.Setup(_ => _.Expressiontreefactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(false);

            //            mTree.Setup(_ => _.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
            //mTree.Setup(_ => _.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);
            mTree.Setup(_ => _.Root.Evaluate()).Returns(5);

            double result = mTree.Object.Evaluate();

            return result;
        }

        public static double IntegrateEvaluateEvaluate()
        {
            //Mock object
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            //mTree.Setup(_ => _.Evaluate()).Returns(12);

            //mTree.Setup(_ => _.ShuntingYardAlgorithm()).Returns(new List<ExpressionNode>() { new ConstantNode(5) });

            //mTree.Setup(_ => _.Expressiontreefactory.CreateOperatorNode(It.IsAny<char>())).Returns(It.IsAny<OperatorNode>());
            //mTree.Setup(_ => _.Expressiontreefactory.IsValidOperator(It.IsAny<char>())).Returns(false);

            //mTree.Setup(_ => _.Expressiontreefactory.CreateTrigOperatorNode(It.IsAny<char>(), It.IsAny<double>(), It.IsAny<char>())).Returns(It.IsAny<TrigNode>());
            //mTree.Setup(_ => _.Expressiontreefactory.IsValidTrigOperator(It.IsAny<char>())).Returns(false);

            //mTree.Setup(_ => _.Expressiontreefactory.IsHigherPrecedence(It.IsAny<char>(), It.IsAny<char>())).Returns(false);

            //            mTree.Setup(_ => _.ConstructTree(It.IsAny<List<ExpressionNode>>())).Returns(new ConstantNode(5));
            //mTree.Setup(_ => _.Evaluate(It.IsAny<ExpressionNode>())).Returns(5);
            //mTree.Setup(_ => _.Root.Evaluate()).Returns(5);

            double result = mTree.Object.Evaluate();
            ExpressionTree tree = mTree.Object;

            //Console.WriteLine("expression={0}", mTree.Object.infixexpression);
            Console.WriteLine("mValue = {0}", result);
            Console.WriteLine("aValue = {0}", tree.Evaluate());

            return result;
        }


        /*        public double IntegrateEvalutate()
                {
                    ExpressionTree tree = new ExpressionTree("5");
                    Mock<ExpressionTree> mTree = new Mock<ExpressionTree>(tree);

                    MethodInfo shuntingYardMethod = GetMethod("ShuntingYardAlgorithm", mTree.Object, Type.EmptyTypes);

                    mTree.Setup(m => m.Evaluate()).Returns(5);

                    //Call the method
                    return mTree.Object.Evaluate();
                }


                //Integration tests for the Shunting Yard
                public void IntegrateCreateOperatorNode()
                {
                    ExpressionTreeFactory treeFactory = new ExpressionTreeFactory();

                    Mock<ExpressionTree> mTree = new Mock<ExpressionTree>();

                    Mock<ExpressionTreeFactory> mTreeFactory = new Mock<ExpressionTreeFactory>("2+2");

                    mTree.Setup(m => m.Expressiontreefactory.IsValidOperator('+')).Returns(true);
                    mTree.Setup(m => m.Expressiontreefactory.IsValidTrigOperator('t')).Returns(false);
                    mTree.Setup(m => m.Expressiontreefactory.CreateTrigOperatorNode('t', 2, 'D')).Returns(value: null);
                    mTree.Setup(m => m.Expressiontreefactory.CreateOperatorNode('+')).Returns(value: new AddNode());

                    MethodInfo sYardMethodInfo = GetMethod("ShuntingYardAlgorithm", mTree.Object, Type.EmptyTypes);

                    object returnedList = sYardMethodInfo.Invoke(mTree.Object, null);

                    returnedList = returnedList as System.Collections.Generic.List<ExpressionNode>;

                    System.Collections.Generic.List<ExpressionNode> expectedList = new System.Collections.Generic.List<ExpressionNode>();
                    expectedList.Add(new ConstantNode(2));
                    expectedList.Add(new ConstantNode(2));
                    expectedList.Add(new AddNode());

                    Assert.AreEqual(expectedList, returnedList);
                }


                private static object GetInstanceField(Type type, object instance, string fieldName)
                {
                    BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                        | BindingFlags.Static;
                    FieldInfo field = type.GetField(fieldName, bindFlags);
                    return field.GetValue(instance);
                }

                private MethodInfo GetMethod(string methodName, object instance, Type[] parameterTypes)
                {
                    if (string.IsNullOrWhiteSpace(methodName))
                    {
                        Assert.Fail("method Name cannot be null or whitespace");
                    }

                    var method = instance.GetType()
                        .GetMethod(
                            methodName,
                            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance,
                            null,
                            CallingConventions.Any,
                            parameterTypes,
                            null);

                    if (method == null)
                    {
                        Assert.Fail(string.Format("{0} method not found", methodName));
                    }

                    return method;
                }
        */
    }
  }
