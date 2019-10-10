// <copyright file="ExpressionTreeFactory.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// In charge of the dirty work
    /// </summary>
    internal class ExpressionTreeFactory
    {
        /// <summary>
        /// A dictionary for the new operators
        /// </summary>
        private Dictionary<char, Type> operators = new Dictionary<char, Type>();

        /// A dictionary for the new trig operators
        /// </summary>
        private Dictionary<char, Type> trigOperators = new Dictionary<char, Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTreeFactory"/> class.
        /// The expression tree constructor
        /// </summary>
        public ExpressionTreeFactory()
        {
            this.TraverseAvailableOperators((op, type) => this.operators.Add(op, type));
            this.TraverseAvailableTrigOperators((trigOp, type) => this.trigOperators.Add(trigOp, type));
        }

        /// <summary>
        /// A delegate for the current operator
        /// </summary>
        /// <param name="op">A character representing the operator</param>
        /// <param name="type">The type of operator</param>
        private delegate void OnOperator(char op, Type type);

        /// <summary>
        /// A delegate for the current TrigOperator
        /// </summary>
        /// <param name="op">A string representing the TrigOperator</param>
        /// <param name="type">The type of TrigOperator</param>
        private delegate void OnTrigOperator(char trigOp, Type type);

        /// <summary>
        /// Creates the new operator
        /// </summary>
        /// <param name="op">The operator character</param>
        /// <returns>The new node</returns>
        public OperatorNode CreateOperatorNode(char op)
        {
            if (this.operators.ContainsKey(op))
            {
                object operatorNodeObject = System.Activator.CreateInstance(this.operators[op]);
                if (operatorNodeObject is OperatorNode)
                {
                    return (OperatorNode)operatorNodeObject;
                }
            }

            throw new Exception("Unhandled Operator!");
        }

        /// <summary>
        /// Creates the new TrigOperator
        /// </summary>
        /// <param name="op">The trig operator string</param>
        /// <returns>The new node</returns>
        public TrigNode CreateTrigOperatorNode(char trigOp, double value, char measurement)
        {
            if (this.trigOperators.ContainsKey(trigOp))
            {
                object trigOperatorNodeObject = System.Activator.CreateInstance(this.trigOperators[trigOp], new object[] { value, measurement });
                if (trigOperatorNodeObject is TrigNode)
                {
                    return (TrigNode)trigOperatorNodeObject;
                }
            }

            throw new Exception("Unhandled TrigOperator!");
        }

        /// <summary>
        /// Compares the precedence of the two operators
        /// </summary>
        /// <param name="opA">The left operator</param>
        /// <param name="opB">The right operator</param>
        /// <returns>A bool</returns>
        public bool IsHigherPrecedence(char opA, char opB)
        {
            Type operatorA = this.operators[opA];
            Type operatorB = this.operators[opB];

            PropertyInfo precedencePropertyA = operatorA.GetProperty("Precedence");
            PropertyInfo precedencePropertyB = operatorB.GetProperty("Precedence");

            return (ushort)precedencePropertyA.GetValue(operatorA) <= (ushort)precedencePropertyB.GetValue(operatorB);
        }

        /// <summary>
        /// Checks to make sure the operator is valid
        /// </summary>
        /// <param name="op">The character</param>
        /// <returns>A bool</returns>
        public bool IsValidOperator(char op)
        {
            if (new ExpressionTreeFactory().operators.ContainsKey(op))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks to make sure the TrigOperator is valid
        /// </summary>
        /// <param name="trigOp">The Trig representation as a string</param>
        /// <returns>A bool</returns>
        public bool IsValidTrigOperator(char trigOp)
        {
            if (new ExpressionTreeFactory().trigOperators.ContainsKey(trigOp))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Traverse through the operators
        /// </summary>
        /// <param name="onOperator">The current operator</param>
        private void TraverseAvailableOperators(OnOperator onOperator)
        {
            Type operatorNodeType = typeof(OperatorNode);
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                IEnumerable<Type> operatorTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(operatorNodeType));
                foreach (var type in operatorTypes)
                {
                    PropertyInfo operatorField = type.GetProperty("Operator");
                    if (operatorField != null)
                    {
                        object value = operatorField.GetValue(type);
                        if (value is char)
                        {
                            char operatorSymbol = (char)value;
                            onOperator(operatorSymbol, type);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Traverse through the TrigOperators
        /// </summary>
        /// <param name="onOperator">The current TrigOperator</param>
        private void TraverseAvailableTrigOperators(OnTrigOperator onTrigOperator)
        {
            Type operatorNodeType = typeof(TrigNode);
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                IEnumerable<Type> operatorTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(operatorNodeType));
                foreach (var type in operatorTypes)
                {
                    PropertyInfo operatorField = type.GetProperty("TrigName");
                    if (operatorField != null)
                    {
                        object value = operatorField.GetValue(type);
                        if (value is char)
                        {
                            char operatorSymbol = (char)value;
                            onTrigOperator(operatorSymbol, type);
                        }
                    }
                }
            }
        }


    }
}