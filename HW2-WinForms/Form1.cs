// <copyright file="Form1.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace HW2_WinForms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Displays the number of distinct values from a list using various methods.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.RunDistinctIntegers();
        }

        /// <summary>
        /// Runs the various methods and outputs the results into a textbox.
        /// </summary>
        private void RunDistinctIntegers()
        {
            int minRange = 0;
            int maxRange = 20000;
            int length = 10000;
            List<int> theList = this.CreateRandomList(length, minRange, maxRange);
            int hashDistinct = Distinct.HashDistinct(theList);
            int bigO1Distinct = Distinct.O1Distinct(minRange, maxRange, theList);
            int sortDistinct = Distinct.SortDistinct(theList);

            this.textBox1.AppendText("1. HashSet method: " + hashDistinct);
            this.textBox1.AppendText(Environment.NewLine + "    The time complexity of the HashSet method is θ(n), where n is the size of the randomized list.");
            this.textBox1.AppendText(Environment.NewLine + "    The method must iterate through each item in the list to add to the hashset, which is θ(n), and the hash.count method is O(1).");
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText("2. O(1) storage method: " + bigO1Distinct);
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText("3. Sorted method: " + sortDistinct);
            this.textBox1.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Creates a list of random integers.
        /// </summary>
        /// <param name="length"> number of elements in the list. </param>
        /// <param name="minRange"> minimum range of random integers. </param>
        /// <param name="maxRange"> maximum range of random integers. </param>
        /// <returns> a list of random integers. </int></returns>
        private List<int> CreateRandomList(int length, int minRange, int maxRange)
        {
            Random random = new Random();
            List<int> outputList = new List<int>();
            for (int i = 0; i < length; i++)
            {
                outputList.Add(random.Next(minRange, maxRange));
            }

            return outputList;
        }
    }
}
