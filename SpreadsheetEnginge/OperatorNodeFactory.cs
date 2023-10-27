// <copyright file="OperatorNodeFactory.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;

    /// <summary>
    /// Creates different operatornodes based on the input operator string.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// Creates approriate operator nodes based on char input.
        /// </summary>
        /// <param name="oper"> char of operator. </param>
        /// <returns> a node inheriting OperatorNode. </returns>
        public static OperatorNode CreateOperatorNode(char oper)
        {
            switch (oper)
            {
                case '+':
                    AdditionNode add = new AdditionNode();
                    return add;
                case '-':
                    SubtractionNode sub = new SubtractionNode();
                    return sub;
                case '*':
                    MultiplicationNode mul = new MultiplicationNode();
                    return mul;
                case '/':
                    DivisionNode div = new DivisionNode();
                    return div;
                case '^':
                    ExponentNode exp = new ExponentNode();
                    return exp;
                case '(':
                    ParenthesisNode par = new ParenthesisNode();
                    return par;
            }

            throw new Exception("Operater not supported");
        }
    }
}
