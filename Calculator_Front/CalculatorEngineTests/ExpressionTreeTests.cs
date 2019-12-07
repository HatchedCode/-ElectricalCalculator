using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorEngine;
using System.Reflection;

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

            //testing addition
            ExpressionTree tree = new ExpressionTree("20+1");
            Assert.AreEqual(21, tree.Evaluate());
            ////Negatives do not work(needs to be fixed
                //negative input
            //tree = new ExpressionTree("20+n1");
           // Assert.AreEqual( 19, tree.Evaluate());
                //negative answer
            //tree = new ExpressionTree("n20+1");
            //Assert.AreEqual( -19, tree.Evaluate());



            //testing multiplication
            tree = new ExpressionTree("21*11");
            Assert.AreEqual( 231, tree.Evaluate());
            //testing division
                //int
            tree = new ExpressionTree("14/2");
            Assert.AreEqual( 7, tree.Evaluate());
            //double
            //tree = new ExpressionTree("14/3");
            //Assert.AreEqual(tree.Evaluate(), 14/3);

            //testing subtraction
                //positive
            tree = new ExpressionTree("14-2");
            Assert.AreEqual( 12, tree.Evaluate());
                //negative
            tree = new ExpressionTree("2-12");
            Assert.AreEqual( -10, tree.Evaluate());

            //testing cos,
                //Rad
            tree = new ExpressionTree("cR(0)");
            Assert.AreEqual( 1, tree.Evaluate());
                //Deg
            tree = new ExpressionTree("cD(90)");
            Assert.AreEqual( 0, tree.Evaluate());

            //testing sin
                //Rad
            tree = new ExpressionTree("sR(0)");
            Assert.AreEqual( 0, tree.Evaluate());
                //Deg
            tree = new ExpressionTree("sD(90)");
            Assert.AreEqual( 1, tree.Evaluate());

            //testing tan
                //Rad
            tree = new ExpressionTree("tR(0)");
            Assert.AreEqual( 0, tree.Evaluate());
                //Deg
            tree = new ExpressionTree("tD(45)");
            Assert.AreEqual( 1, tree.Evaluate());

            //testing csc
                //Rad
            tree = new ExpressionTree("SR(1)");
            Assert.AreEqual(1.1883951057781212d, tree.Evaluate());
                //Deg
            tree = new ExpressionTree("SD(45)");
            Assert.AreEqual(1.4141999999999999d, tree.Evaluate());

            //testing sec
                //Rad
            tree = new ExpressionTree("CR(0)");
            Assert.AreEqual(1, tree.Evaluate());
                //Deg
            tree = new ExpressionTree("CD(45)");
            Assert.AreEqual(1.4141999999999999d, tree.Evaluate());


            //testing cot
            //Rad
            tree = new ExpressionTree("TR(3.14)");
            Assert.AreEqual(14, tree.Evaluate());
            //Deg
            tree = new ExpressionTree("TD(45)");
            Assert.AreEqual(1, tree.Evaluate());

            //testing mod
            tree = new ExpressionTree("10%3");
            Assert.AreEqual(1, tree.Evaluate());
            tree = new ExpressionTree("10%2");
            Assert.AreEqual(0, tree.Evaluate());

            //tesiting paren
            tree = new ExpressionTree("100+(2*4)*2");
            Assert.AreEqual(116, tree.Evaluate());


            //....

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
            //checks if Left is 1
            Assert.AreEqual(Left.Value, 1);
            
            //checks if Right is a constant Node
            Assert.IsTrue(temp.Right is ConstantNode);
            ConstantNode Right = (ConstantNode)temp.Right;
            //checks if Right is 20
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

        [TestMethod]
        public void TestConstructor()
        {
            ExpressionTree tree = new ExpressionTree("20+1");

            PrivateObject privateTree = new PrivateObject(tree);

            var ret = privateTree.GetField("infixexpression");
            Assert.AreEqual("20+1", ret);

            tree = new ExpressionTree("");

            PrivateObject privateTreeEmpty = new PrivateObject(tree);

             ret = privateTreeEmpty.GetField("infixexpression");
            Assert.AreEqual("", ret);
        }

        [TestMethod]
        public void TestSetVariable()
        {
            ExpressionTree tree = new ExpressionTree("20+1");

            tree.SetVariable("hello", 100);
            tree.SetVariable("World", 200);
            PrivateObject privateTree = new PrivateObject(tree);


            var ret = privateTree.GetField("variables");
            System.Collections.Generic.Dictionary<string, double> vars = (System.Collections.Generic.Dictionary<string, double>)ret;
           
            Assert.AreEqual(100, vars["hello"]);
            Assert.AreEqual(200, vars["World"]);

        
        }

        [TestMethod]
        public void TestGetVariableNames()
        {
            ExpressionTree tree = new ExpressionTree("20+1");
            System.Collections.Generic.Dictionary<string, double> vars = new System.Collections.Generic.Dictionary<string, double>();
            vars["hello"] = 100;
            vars["world"] = 200;

            //checks empty dicionary
            Assert.AreEqual(0, tree.GetVariableNames().Length);

            //sets Dictionary
            PrivateObject privateTree = new PrivateObject(tree);
            privateTree.SetField("variables", vars);

            //checks non empty tree
            string[] ret = tree.GetVariableNames();
            Assert.AreEqual("hello", ret[0]);
            Assert.AreEqual("world", ret[1]);


        }


        //Black Box

        [TestMethod]
        public void TestEvaluateBlackBox()
        {

            /*----------------------------------------------
             *inputs      | Expected output
             * positives
             * 1+1        | 2
             * 4-1        | 3
             * 2*4        | 8
             * 4/2        | 2
             * 9%2        | 1
             * COS(RAD(0) |1
             * Sin(Deg(90))
             * 
             * zeros
             * 0+0        |0
             * 2-2        |0
             * 2*0        |0
             * 0/2        |0
             * 0%2        |0
             * Cos(deg(1)) |0
             * Sin(Rad(0)  |0
             * Negatives
             * -10+1      |-9
             * 4-5        |-1
             * -2*2       |-4
             * -4/2       |-2
             * -11%2      |1
             * Errors?
             * 1/0
             * 1%0
             * a+3
            ------------------------------------------------
             */
            ExpressionTree tree = new ExpressionTree("");


            //positives
            tree = new ExpressionTree("1+1");
            Assert.AreEqual(2, tree.Evaluate());
            tree = new ExpressionTree("4-1");
            Assert.AreEqual(3, tree.Evaluate());
            tree = new ExpressionTree("2*4");
            Assert.AreEqual(8, tree.Evaluate());
            tree = new ExpressionTree("4/2");
            Assert.AreEqual(2, tree.Evaluate());
            tree = new ExpressionTree("9%2");
            Assert.AreEqual(1, tree.Evaluate());
            //Rad
            tree = new ExpressionTree("cR(0)");
            Assert.AreEqual(1, tree.Evaluate());
            //Deg
            tree = new ExpressionTree("sD(90)");
            Assert.AreEqual(1, tree.Evaluate());

            //zeros
            tree = new ExpressionTree("0+0");
            Assert.AreEqual(0, tree.Evaluate());
            tree = new ExpressionTree("2-2");
            Assert.AreEqual(0, tree.Evaluate());
            tree = new ExpressionTree("2*0");
            Assert.AreEqual(0, tree.Evaluate());
            tree = new ExpressionTree("0/2");
            Assert.AreEqual(0, tree.Evaluate());
            tree = new ExpressionTree("0%2");
            Assert.AreEqual(0, tree.Evaluate());
            //Deg
            tree = new ExpressionTree("cD(90)");
            Assert.AreEqual(0, tree.Evaluate()); 
            //Rad
            tree = new ExpressionTree("sR(0)");
            Assert.AreEqual(0, tree.Evaluate());


            //negatives (did not impliment negative into programm yet)
            //tree = new ExpressionTree("n10+1");
            //Assert.AreEqual(-9, tree.Evaluate());
            tree = new ExpressionTree("4-5");
            Assert.AreEqual(-1, tree.Evaluate());
            //tree = new ExpressionTree("-4*2");
            //Assert.AreEqual(-8, tree.Evaluate());
            //tree = new ExpressionTree("n4/2");
            //Assert.AreEqual(2, tree.Evaluate());
            //tree = new ExpressionTree("n11%2");
            //Assert.AreEqual(1, tree.Evaluate());

            //currently return ininity
            //tree = new ExpressionTree("1/0");
            //Assert.Fail("Divide by Zero", tree.Evaluate());

            // tree = new ExpressionTree("1%0");
            //Assert.Fail("Divide by Zero", tree.Evaluate());   
          
         

        }

        [TestMethod]
        public void TestConstructTreeBlackBox()
        {
            /*  input                   |   output
             * varNode,varNode,addNode |   addNode
             * varNode,varNode,subtractNode |   subtractNode
             * varNode,varNode,MultiplyNode |   MultiplyNode
             * varNode,varNode,DivideNode |   DivideNode
             * varNode,varNode,ModNode |   ModNode
             * varNode                  | var Node
             */

            //Add node
            ExpressionTree tree = new ExpressionTree("20+1");
            PrivateObject t = new PrivateObject(tree);
            System.Collections.Generic.List<ExpressionNode> postfixList = new System.Collections.Generic.List<ExpressionNode>();
            postfixList.Add(new ConstantNode(1));
            postfixList.Add(new ConstantNode(5));
            postfixList.Add(new AddNode());

            Object ret = t.Invoke("ConstructTree", postfixList);
            ExpressionNode head = (ExpressionNode)ret;

            
            Assert.IsTrue(head is AddNode);

            //subtract Node
            postfixList = new System.Collections.Generic.List<ExpressionNode>();
            postfixList.Add(new ConstantNode(1));
            postfixList.Add(new ConstantNode(5));
            postfixList.Add(new SubtractNode());

            ret = t.Invoke("ConstructTree", postfixList);
            head = (ExpressionNode)ret;

            Assert.IsTrue(head is SubtractNode);

            //Divide Node
            postfixList = new System.Collections.Generic.List<ExpressionNode>();
            postfixList.Add(new ConstantNode(1));
            postfixList.Add(new ConstantNode(5));
            postfixList.Add(new DivideNode());

            ret = t.Invoke("ConstructTree", postfixList);
            head = (ExpressionNode)ret;

            Assert.IsTrue(head is DivideNode);

            //Multiply Node
            postfixList = new System.Collections.Generic.List<ExpressionNode>();
            postfixList.Add(new ConstantNode(1));
            postfixList.Add(new ConstantNode(5));
            postfixList.Add(new MultiplyNode());

            ret = t.Invoke("ConstructTree", postfixList);
            head = (ExpressionNode)ret;

            Assert.IsTrue(head is MultiplyNode);

            //Constant Node
            postfixList = new System.Collections.Generic.List<ExpressionNode>();
            postfixList.Add(new ConstantNode(1));

            ret = t.Invoke("ConstructTree", postfixList);
            head = (ExpressionNode)ret;

            Assert.IsTrue(head is ConstantNode);
        }
    }
}


