// <copyright file="Program.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace ExpressionTreeApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SpreadsheetEngine;

    /// <summary>
    /// console app to create and modify and expression tree.
    /// </summary>
    public class Program
    {
        private static ExpressionTree expressionTree = new ExpressionTree("3+2-1");

        private static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int choice = -1;
                    DisplayMenu();
                    choice = Convert.ToInt32(Console.ReadLine());
                    MenuSwitch(choice);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please try again.");
                    continue;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Menu (Current expression = \"" + CurrentExpression() + "\" )");
            Console.WriteLine("1 = Enter a new expression");
            Console.WriteLine("2 = Set a variable value");
            Console.WriteLine("3 = Evaluate Tree");
            Console.WriteLine("4 = Quit");
        }

        private static void MenuSwitch(int option)
        {
            switch (option)
            {
                case 1:
                    ChangeExpression();
                    break;

                case 2:
                    AddVariable();
                    break;

                case 3:
                    Console.WriteLine("Evaluating...");
                    Console.WriteLine(expressionTree.Evaluate());
                    break;

                case 4:
                    Console.WriteLine("Goodbye.");
                    System.Threading.Thread.Sleep(1000);
                    Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("Please try again.");
                    break;
            }
        }

        private static string CurrentExpression()
        {
            // TODO
            return string.Empty;
        }

        private static void ChangeExpression()
        {
            // TODO
        }

        private static void AddVariable()
        {
            // TODO
        }
    }
}
