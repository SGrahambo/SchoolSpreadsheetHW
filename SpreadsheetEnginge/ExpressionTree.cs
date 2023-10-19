// <copyright file="ExpressionTree.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Creates and expression tree from a string and evaluates the expression into a double.
    /// </summary>
    public class ExpressionTree
    {
        private static Dictionary<string, double> variableDict = new Dictionary<string, double>();

        private string expression;
        private Node root;
        private int maxPrecidence = 0;
        private List<Node> nodeList = new List<Node>();

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
        /// Goes through the tree and performs the necessart operations on each node.
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
                return operatorNode.Operate();
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
            int i = 0;

            while (i <= s.Length - 1)
            {
                int a = i; // beginning of substring.

                // Creates an OperatorNode if the current char is an operator.
                if (OperatorNode.ValidOperators(s[i]))
                {
                    // if operator is a '-' and the previous char is an operator, it treats it like part of a number.
                    if (s[i] == '-' && (i == 0 || OperatorNode.ValidOperators(s[i - 1])))
                    {
                        i++;
                    }
                    else
                    {
                        Node node = new OperatorNode(s[i].ToString());
                        this.nodeList.Add(node);
                        i++;
                        if (node.Precidence > this.maxPrecidence)
                        {
                            this.maxPrecidence = node.Precidence;
                        }

                        continue;
                    }
                }

                double number;

                // create ConstantNode if next character is a number and tryparse substring before next operator.
                if (double.TryParse(s[i].ToString(), out number))
                {
                    // Sets i to index before next operator.
                    while (i < s.Length - 1 && !OperatorNode.ValidOperators(s[i + 1]))
                    {
                        i++;
                        continue;
                    }

                    double.TryParse(s.Substring(a, i + 1 - a), out number);
                    ConstantNode node = new ConstantNode();
                    node.Value = number;
                    this.nodeList.Add(node);
                    i++;
                    continue;
                }
                else
                {
                    // substring before next operator added to new VariableNode.
                    while (i < s.Length - 1 && !OperatorNode.ValidOperators(s[i + 1]))
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

                    this.nodeList.Add(node);
                    i++;
                }
            }
        }

        private void CreateTree()
        {
            List<Node> reverseList = this.nodeList;
            reverseList.Reverse();
            for (int i = this.maxPrecidence; i >= 0; i--)
            {
                foreach (Node node in reverseList)
                {
                    if (node.Precidence == i)
                    {
                        if (this.root == null)
                        {
                            this.root = node;
                        }
                        else
                        {
                            this.AddToTree(this.root, node);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void AddToTree(Node pointer, Node node)
        {
            if (node.Precidence < pointer.Precidence)
            {
                if (pointer.Right == null)
                {
                    pointer.Right = node;
                }
                else if (pointer.Left == null)
                {
                    pointer.Left = node;
                }
                else if (pointer.Right.Precidence > node.Precidence)
                {
                    this.AddToTree(pointer.Right, node);
                }
                else
                {
                    this.AddToTree(pointer.Left, node);
                }
            }
            else
            {
                if (pointer.Left == null)
                {
                    pointer.Left = node;
                }
                else
                {
                    this.AddToTree(pointer.Left, node);
                }
            }
        }
    }
}
