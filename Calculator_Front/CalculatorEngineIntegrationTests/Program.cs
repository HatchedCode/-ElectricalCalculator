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
        static void Main(string[] args)
        {
            double result = 0, expected = 0;

            Console.WriteLine("Starting Integration Testing\n");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");
            result = IntegrationTests.IntegrateEvaluate();
            expected = 12;
            Console.WriteLine("Step 0: Integrate Evaluate: E={0} R={1} = {2}\n",expected, result, expected == result);

            result = IntegrationTests.IntegrateShuntingYard();
            expected = 5;
            Console.WriteLine("Step 1: Integrate ShuntingYardAlgorithm: E={0} R={1} = {2}\n", expected, result, expected == result);

            result = IntegrationTests.IntegrateConstructTree();
            expected = 5;
            Console.WriteLine("Step 2: Integrate ConstructTree: E={0} R={1} = {2}\n", expected, result, expected == result);



            result = IntegrationTests.IntegrateExpressionEvaluate();
            expected = 12;
            Console.WriteLine("Step 3: Integrate Evaluate: E={0} R={1} = {2}\n", expected, result, expected == result);

            result = IntegrationTests.IntegrateIsValidTrigOperator();
            expected = 5;
            Console.WriteLine("Step 4: Integrate ShuntingYardAlgorithm: E={0} R={1} = {2}\n", expected, result, expected == result);

            result = IntegrationTests.IntegrateCreateTrigOperatorNode();
            expected = 5;
            Console.WriteLine("Step 5: Integrate ConstructTree: E={0} R={1} = {2}\n", expected, result, expected == result);



            result = IntegrationTests.IntegrateIsValidOperator();
            expected = 12;
            Console.WriteLine("Step 6: Integrate Evaluate: E={0} R={1} = {2}\n", expected, result, expected == result);

            result = IntegrationTests.IntegrateCreateOperatorNode();
            expected = 5;
            Console.WriteLine("Step 7: Integrate ShuntingYardAlgorithm: E={0} R={1} = {2}\n", expected, result, expected == result);

            result = IntegrationTests.IntegrateIsHigherPrecedence();
            expected = 5;
            Console.WriteLine("Step 8: Integrate ConstructTree: E={0} R={1} = {2}\n", expected, result, expected == result);


            result = IntegrationTests.IntegrateEvaluateEvaluate();
            expected = 12;
            Console.WriteLine("Step 9: Integrate Evaluate: E={0} R={1} = {2}\n", expected, result, expected == result);

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("Finished integration testing\n");
        }
    }
}
