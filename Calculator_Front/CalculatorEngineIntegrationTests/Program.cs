using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorEngine;
using Moq;
using NUnit.Framework;

namespace CalculatorEngineIntegrationTests
{
    class Program
    {
        //private static IntegrationTests tests = new IntegrationTests();
        static void Main(string[] args)
        {
            Console.WriteLine("IntegrateEvaluate = {0}\n", IntegrateEvalutate() == 5);
        }

        public static  double IntegrateEvalutate()
        {
            ExpressionTree tree = new ExpressionTree("5");
            Mock<ExpressionTree> mTree = new Mock<ExpressionTree>("5");

            //https://stackoverflow.com/questions/56905578/moq-non-overridable-members-may-not-be-used-in-setup-verification-expression
            mTree.Setup(m => m.Evaluate()).Returns(5);

            //Call the method
            return mTree.Object.Evaluate();
        }
    }
}
