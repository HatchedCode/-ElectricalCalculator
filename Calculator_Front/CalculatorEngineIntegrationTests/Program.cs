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
            Console.WriteLine("Step 0: Integrate with Interface Body Evaluate: E={0} R={1} = {2}\n", expected, result, expected == result);

            result = IntegrationTests.IntegrateShuntingYard();
            expected = 12;
            Console.WriteLine("Step 1: Integrate with Interface Body ShuntingYard: E={0} R={1} = {2}\n", expected, result, expected == result);

            result = IntegrationTests.IntegrateConstructTree();
            expected = 5;
            Console.WriteLine("Step 2: Integrate with Interface Body ConstructTree: E={0} R={1} = {2}\n", expected, result, expected == result);

            result = IntegrationTests.IntegrateExpressionEvaluate();
            expected = 0;
            Console.WriteLine("Step 3: Integrate with Interface Body ExpressionEvaluate: E={0} R={1} = {2}\n", expected, result, expected == result);

            result = IntegrationTests.IntegrateEvaluateEvaluate();
            expected = 35;
            Console.WriteLine("Step 9: Integrate Evaluate: E={0} R={1} = {2}\n", expected, result, expected == result);

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("Finished integration testing\n");
        }
    }
}
