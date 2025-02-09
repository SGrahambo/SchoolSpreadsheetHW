﻿// <copyright file="ExpressionTreeTests.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace SpreadsheetEngine.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests the ExpressionTree class.
    /// </summary>
    public class ExpressionTreeTests
    {
        private ExpressionTree expressionTree;

        /// <summary>
        /// Creates expression and evaluates it. Only using one kind of operator.
        /// </summary>
        /// <param name="s"> expression string. </param>
        /// <param name="d"> expected evaluate double. </param>
        [TestCase("5+1+2", 8)]
        [TestCase("5-1-2", 2)]
        [TestCase("5*1*2", 10)]
        [TestCase("5/1/2", 2.5)]
        [TestCase("5+1+-2", 4)]
        [TestCase("5-1--2", 6)]
        [TestCase("5*1*-2", -10)]
        [TestCase("5/1/-2", -2.5)]
        [TestCase("5+1+-2+0", 4)]
        [TestCase("5-1--2-0", 6)]
        [TestCase("5*1*-2*0", 0)]
        [TestCase("5/1/-2/0", double.NegativeInfinity)]
        [TestCase("5/1/2/0", double.PositiveInfinity)]
        public void TestSingleOperators(string s, double d)
        {
            this.expressionTree = new ExpressionTree(s);
            Assert.AreEqual(d, this.expressionTree.Evaluate());
        }

        /// <summary>
        /// Creates expression with different operations to test order of operations.
        /// </summary>
        /// <param name="s"> expression string. </param>
        /// <param name="d"> expected evaluate double. </param>
        [TestCase("5-3+1", 3)]
        [TestCase("5+3-1*5-3+1", 1)]
        [TestCase("10*5/2", 25)]
        [TestCase("10/5*2", 4)]
        [TestCase("6030/3*5+2", 10052)]
        [TestCase("60+30*3/5-2", 76)]
        [TestCase("60/30-3+5*2", 9)]
        [TestCase("60/30-3^3+5*2", -15)]
        [TestCase("60*30+3-5/2", 1800.5)]
        [TestCase("60*30+3-5/0", double.NegativeInfinity)]

        // [TestCase("4^3^2", 262144)]
        public void TestOrderOfOperations(string s, double d)
        {
            this.expressionTree = new ExpressionTree(s);
            Assert.AreEqual(d, this.expressionTree.Evaluate());
        }

        /// <summary>
        /// Creates expression with different operations and parenthesis to test order of operations.
        /// </summary>
        /// <param name="s"> expression string. </param>
        /// <param name="d"> expected evaluate double. </param>
        [TestCase("10+1/8-3+4*6", 31.125)]
        [TestCase("10+1/8-3+(4*6)", 31.125)]
        [TestCase("10+1/8-(3+(4*6))", -16.875)]
        [TestCase("(10+1)/8-(3+(4*6))", -25.625)]
        [TestCase("10+(1/8-3+4)*6", 16.75)]
        [TestCase("(10+(1/(8-3)+4)*6)", 35.2)]
        [TestCase("(((10+(1/(8-3)+4)*6)))", 35.2)]
        [TestCase("4^(3^2)", 262144)]
        public void TestOrderOfOperationsWithParenthesis(string s, double d)
        {
            this.expressionTree = new ExpressionTree(s);
            Assert.AreEqual(d, this.expressionTree.Evaluate());
        }

        /// <summary>
        /// Sets expression tree and variable names and values, then evaluates expression tree.
        /// </summary>
        [Test]
        public void TestVariables()
        {
            this.expressionTree = new ExpressionTree("This+better+work");

            this.expressionTree.SetVariable("This", 1);
            this.expressionTree.SetVariable("better", 2);
            this.expressionTree.SetVariable("work", 3);

            Assert.That(this.expressionTree.Evaluate(), Is.EqualTo(6));
        }

        /// <summary>
        /// Sets variables first before evaluating expression tree.
        /// </summary>
        [Test]
        public void TestSetVariablesFirst()
        {
            this.expressionTree.SetVariable("This", 1);
            this.expressionTree.SetVariable("better", 2);
            this.expressionTree.SetVariable("work", 3);

            this.expressionTree = new ExpressionTree("This+better+work");

            Assert.That(this.expressionTree.Evaluate(), Is.EqualTo(0));
        }

        /// <summary>
        /// Sets expression, sets variables, and evaluates expression. Then changes expression with same variable names and evaulates again.
        /// </summary>
        [Test]
        public void TestVariablesSwap()
        {
            this.expressionTree = new ExpressionTree("This+better+work");

            this.expressionTree.SetVariable("This", 1);
            this.expressionTree.SetVariable("better", 2);
            this.expressionTree.SetVariable("work", 3);

            Assert.That(this.expressionTree.Evaluate(), Is.EqualTo(6));

            this.expressionTree = new ExpressionTree("better-work-This");

            Assert.That(this.expressionTree.Evaluate(), Is.EqualTo(0));
        }

        /// <summary>
        /// Sets expression with variable name and constants and evaluates.
        /// </summary>
        [Test]
        public void TestVariablesAndConstants()
        {
            this.expressionTree = new ExpressionTree("10-This-better--1-work");

            this.expressionTree.SetVariable("This", 1);
            this.expressionTree.SetVariable("better", 2);
            this.expressionTree.SetVariable("work", 3);

            Assert.That(this.expressionTree.Evaluate(), Is.EqualTo(5));
        }
    }
}