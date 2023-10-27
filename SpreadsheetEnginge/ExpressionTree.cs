// <copyright file="ExpressionTree.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Creates and expression tree from a string and evaluates the expression into a double.
    /// </summary>
    public class ExpressionTree
    {
        private static Dictionary<string, double> variableDict = new Dictionary<string, double>();

        private string expression;
        private Node root;
        private List<Node> nodeList = new List<Node>();
        private List<Node> postFixList = new List<Node>();
        private Stack<Node> nodeStack = new Stack<Node>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// Takes a string input expression and parses it into nodes and adds to an expression tree.
        /// </summary>
        /// <param name="expressionInput"> expression string. </param>
        public ExpressionTree(string expressionInput)
        {
            variableDict.Clear();

            if (this.nodeList != null)
            {
                this.nodeList.Clear();
            }

            if (expressionInput != string.Empty)
            {
                this.expression = expressionInput.Replace(" ", string.Empty);
                this.CreateNodeList(this.expression);
                this.CreateTree();
            }
        }

        /// <summary>
        /// Modified from in class exercise code.
        /// Goes through the tree and performs the necessart operations on each one.
        /// </summary>
        /// <param name="node"> The root node of the expression tree. </param>
        /// <returns> the value of the node. </returns>
        public static double Evaluate(Node node)
        {
            ConstantNode constantNode = node as ConstantNode;
            if (constantNode != null)
            {
                return constantNode.Value;
            }

            VariableNode variableNode = node as VariableNode;
            if (variableNode != null)
            {
                return variableDict[variableNode.Name];
            }

            OperatorNode operatorNode = node as OperatorNode;
            if (operatorNode != null)
            {
                return operatorNode.Evaluate();
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates a new variable name and value in the variable dictionary.
        /// </summary>
        /// <param name="variableName"> variable name. </param>
        /// <param name="variableValue"> variable value. </param>
        public void SetVariable(string variableName, double variableValue)
        {
            if (variableDict.ContainsKey(variableName))
            {
                variableDict[variableName] = variableValue;
            }
            else
            {
                variableDict.Add(variableName, variableValue);
            }
        }

        /// <summary>
        /// Calculates the value of the expression tree.
        /// </summary>
        /// <returns> double of the expression results. </returns>
        public double Evaluate()
        {
            return Evaluate(this.root);
        }

        /// <summary>
        /// returns the expression string.
        /// </summary>
        /// <returns> expression string. </returns>
        public string GetExpression()
        {
            return this.expression;
        }

        /// <summary>
        /// Parses the expression string into a list of nodes.
        /// </summary>
        /// <param name="s"> expression string. </param>
        private void CreateNodeList(string s)
        {
            this.CheckParenthesisBalance(s);

            int i = 0;

            while (i <= s.Length - 1)
            {
                int a = i; // beginning of substring.

                // Creates an OperatorNode if the current char is an operator.
                if (OperatorNode.ValidOperator(s[i]))
                {
                    // if operator is a '-' and the previous char is an operator, it treats it like part of a number.
                    if (s[i] == '-' && (i == 0 || OperatorNode.ValidOperator(s[i - 1])))
                    {
                        i++;
                    }
                    else if (s[i] == ')')
                    {
                        while (this.nodeStack.Peek().IsParenthesis == false)
                        {
                            this.postFixList.Add(this.nodeStack.Pop());
                        }

                        this.nodeStack.Pop();
                        i++;
                        continue;
                    }
                    else
                    {
                        // Creation of operator nodes.
                        Node node = OperatorNodeFactory.CreateOperatorNode(s[i]);
                        if (this.nodeStack.Count == 0 || node.IsParenthesis || node.Precidence > this.nodeStack.Peek().Precidence)
                        {
                            this.nodeStack.Push(node);
                        }
                        else
                        {
                            while (this.nodeStack.Count > 0 && node.Precidence <= this.nodeStack.Peek().Precidence)
                            {
                                this.postFixList.Add(this.nodeStack.Pop());
                            }

                            this.nodeStack.Push(node);
                        }

                        i++;
                        continue;
                    }
                }

                double number;

                // create ConstantNode if next character is a number and tryparse substring before next operator.
                if (double.TryParse(s[i].ToString(), out number))
                {
                    // Sets i to index before next operator.
                    while (i < s.Length - 1 && !OperatorNode.ValidOperator(s[i + 1]))
                    {
                        i++;
                        continue;
                    }

                    double.TryParse(s.Substring(a, i + 1 - a), out number);
                    ConstantNode node = new ConstantNode();
                    node.Value = number;
                    this.postFixList.Add(node);

                    i++;
                    continue;
                }
                else
                {
                    // substring before next operator added to new VariableNode.
                    while (i < s.Length - 1 && !OperatorNode.ValidOperator(s[i + 1]))
                    {
                        i++;
                        continue;
                    }

                    VariableNode node = new VariableNode();
                    node.Name = s.Substring(a, i + 1 - a);
                    if (variableDict.ContainsKey(node.Name) == false)
                    {
                        variableDict.Add(node.Name, 0);
                    }

                    this.postFixList.Add(node);
                    i++;
                }
            }

            while (this.nodeStack.Count != 0)
            {
                this.postFixList.Add(this.nodeStack.Pop());
            }
        }

        /// <summary>
        /// Checks if string has balanced parenthesis. Returns an exception if not.
        /// </summary>
        /// <param name="s"> string of expression. </param>
        private void CheckParenthesisBalance(string s)
        {
            // checks if parenthesis are balanced
            int parBalance = 0;
            foreach (char c in s)
            {
                if (parBalance >= 0)
                {
                    if (c == '(')
                    {
                        parBalance++;
                    }
                    else if (c == ')')
                    {
                        parBalance--;
                    }
                }
                else
                {
                    break;
                }
            }

            if (parBalance != 0)
            {
                Console.WriteLine("Paranthesis are unbalanced.");
                throw new Exception();
            }
        }

        private void CreateTree()
        {
            // postfix tree
            foreach (Node node in this.postFixList)
            {
                if (node.IsOperand)
                {
                    this.nodeStack.Push(node);
                }
                else
                {
                    node.Right = this.nodeStack.Pop();
                    node.Left = this.nodeStack.Pop();
                    this.nodeStack.Push(node);
                }
            }

            this.root = this.nodeStack.Pop();
        }
    }
}
