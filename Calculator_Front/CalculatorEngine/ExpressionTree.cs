// <copyright file="ExpressionTree.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IExpressionTree
    {
        //Interface Members
        public void SetVariable(string variableName, double variableValue);
        public string[] GetVariableNames();
        public double Evaluate();
        public List<ExpressionNode> ShuntingYardAlgorithm();
        public double Evaluate(ExpressionNode theNode);
        public ExpressionNode ConstructTree(List<ExpressionNode> postfix);
        public ExpressionNode GetRoot();
        public ExpressionTreeFactory GetFactory();

    }

    public class Evaluator
    {
        private IExpressionTree _expressionTree;

        public Evaluator(IExpressionTree tree)
        {
            this._expressionTree = tree;
        }

        public void SetVariable(string variableName, double variableValue)
        {
            this._expressionTree.SetVariable(variableName, variableValue);
        }

        public string[] GetVariableNames()
        {
            return this._expressionTree.GetVariableNames();
        }

        public double Evaluate()
        {
            return this._expressionTree.Evaluate();
        }

        public List<ExpressionNode> ShuntingYardAlgorithm()
        {
            return this._expressionTree.ShuntingYardAlgorithm();
        }

        public double Evaluate(ExpressionNode theNode)
        {
            return this._expressionTree.Evaluate(theNode);
        }

        public ExpressionNode ConstructTree(List<ExpressionNode> postfix)
        {
            return this._expressionTree.ConstructTree(postfix);
        }

        public ExpressionNode GetRoot()
        {
            return this._expressionTree.GetRoot();
        }

        public ExpressionTreeFactory GetFactory()
        {
            return this._expressionTree.GetFactory();
        }

    }

    /// <summary>
    /// The expression tree program
    /// </summary>
    public class ExpressionTree : IExpressionTree
    {
        //Copy constructor
        
        /// <summary>
        /// The root of the tree
        /// </summary>
        private ExpressionNode root;

        /// <summary>
        /// The variables inside the tree
        /// </summary>
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// Calls the factory
        /// </summary>
        private ExpressionTreeFactory treeFactory = new ExpressionTreeFactory();

        /// <summary>
        /// The infix expression
        /// </summary>
        private string infixexpression;

        /// <summary>
        /// Gets or sets the expression
        /// </summary>
        private List<ExpressionNode> Expression { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// Constructor that takes in a string as an argument.
        /// </summary>
        /// <param name="expression">Expression to construct the tree.</param>
        public ExpressionTree(string expression) => this.infixexpression = expression;

/*        public ExpressionTree()
        {
            this.infixexpression = "";
        }*/

        /// <summary>
        /// Makes the variable node
        /// </summary>
        /// <param name="variableName">The name</param>
        /// <param name="variableValue">The value</param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.variables[variableName] = variableValue;
        }

        internal ExpressionTreeFactory Expressiontreefactory => this.treeFactory;

        public ExpressionTreeFactory GetFactory()
        {
            return this.treeFactory;
        }

        public ExpressionNode GetRoot()
        {
            return this.root;
        }

        /// <summary>
        /// Gets the names of the variables in the expression tree
        /// </summary>
        /// <returns></returns>
        public string[] GetVariableNames()
        {
                return this.variables.Keys.ToArray();
        }

        /// <summary>
        /// Evaluates the expression
        /// </summary>
        /// <returns>A number</returns>
        public double Evaluate()
        {
            this.root = this.ConstructTree(this.ShuntingYardAlgorithm());
            return this.Evaluate(this.root);
        }

        /// <summary>
        /// Converts to a postfix; Worked on it in class with Osman Bakari and copied it from the class demo
        /// </summary>
        /// <returns>A postfix expression node list</returns>
        public List<ExpressionNode> ShuntingYardAlgorithm()
        {
            Stack<char> stack = new Stack<char>();
            List<ExpressionNode> output = new List<ExpressionNode>();

            for (int index = 0; index < this.infixexpression.Length; index++)
            {
                if (char.IsLetter(this.infixexpression[index]))
                {

                    if(this.treeFactory.IsValidTrigOperator(this.infixexpression[index]))
                    {
                        char trigFunctionIdentifier = this.infixexpression[index];
                        index += 1;
                        char angleMeasurement = this.infixexpression[index];
                        index += 1;
                        index += 1; // we will skip over the '('

                        string temp = string.Empty;
                        while (index < this.infixexpression.Length && char.IsDigit(this.infixexpression[index]))
                        {
                            temp += this.infixexpression[index];
                            index++;
                        }

                        if(index < this.infixexpression.Length && this.infixexpression[index] == ')') // Checking to see if it is ')'
                        {
                            output.Add(this.treeFactory.CreateTrigOperatorNode(trigFunctionIdentifier, Convert.ToDouble(temp), angleMeasurement));
                        }
                        else
                        {
                            output.Add(this.treeFactory.CreateTrigOperatorNode(trigFunctionIdentifier, Convert.ToDouble(temp), angleMeasurement));
                        }
                    }
                }
                else if (char.IsDigit(this.infixexpression[index]))
                {
                    string temp = string.Empty;
                    while (index < this.infixexpression.Length && char.IsDigit(this.infixexpression[index]))
                    {
                        temp += this.infixexpression[index];
                        index++;
                    }

                    index--;
                    output.Add(new ConstantNode(Convert.ToDouble(temp)));
                }
                else if (this.infixexpression[index] == '(')
                {
                    stack.Push(this.infixexpression[index]);
                }
                else if (this.infixexpression[index] == ')')
                {
                    while (stack.Count != 0 && stack.Peek() != '(')
                    {
                        output.Add(this.treeFactory.CreateOperatorNode(stack.Pop()));
                    }

                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }
                else if (this.treeFactory.IsValidOperator(this.infixexpression[index]))
                {
                    while (stack.Count != 0 && this.treeFactory.IsHigherPrecedence(this.infixexpression[index], stack.Peek()))
                    {
                        output.Add(this.treeFactory.CreateOperatorNode(stack.Pop()));
                    }

                    stack.Push(this.infixexpression[index]);
                }
            }

            while (stack.Count != 0)
            {
                output.Add(this.treeFactory.CreateOperatorNode(stack.Pop()));
            }

            return output;
        }

        /// <summary>
        /// Evaluates the nodes
        /// </summary>
        /// <param name="theNode">The current nodes</param>
        /// <returns>An evaluation</returns>
        public double Evaluate(ExpressionNode theNode)
        {
            double temp = theNode.Evaluate();
            return temp;
        }

        /// <summary>
        /// Constructs the expression tree; Worked on it in class with Osman Bakari and copied it from the class demo
        /// </summary>
        /// <param name="postfix">The string being used</param>
        /// <returns>A expression tree</returns>
        public ExpressionNode ConstructTree(List<ExpressionNode> postfix)
        {
            Stack<ExpressionNode> stackNodes = new Stack<ExpressionNode>();

            foreach (ExpressionNode character in postfix)
            {
                if ((character is OperatorNode) == false)
                {
                    if (character is VariableNode)
                    {
                        if (this.variables.TryGetValue((character as VariableNode).Name, out double variablevalue))
                        {
                            stackNodes.Push(new ConstantNode(variablevalue));
                        }
                        else
                        {
                            stackNodes.Push(new ConstantNode(0));
                        }
                    }
                    else
                    {
                        stackNodes.Push(character);
                    }
                }
                else
                {
                    OperatorNode tempNode = character as OperatorNode;
                    tempNode.Left = stackNodes.Pop();
                    tempNode.Right = stackNodes.Pop();

                    stackNodes.Push(tempNode);
                }
            }

            ExpressionNode tempRootNode = stackNodes.Peek();
            stackNodes.Pop();
            return tempRootNode;
        }
    }
}