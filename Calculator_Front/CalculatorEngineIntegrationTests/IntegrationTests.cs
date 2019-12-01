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
        public IntegrationTests()
        {

        }
        public double IntegrateEvalutate()
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
    }
}
