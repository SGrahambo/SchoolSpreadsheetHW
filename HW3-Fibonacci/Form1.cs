// <copyright file="Form1.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace HW3_Fibonacci
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// basic notepad functionality.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Saves content from textBox1 to file.
        /// </summary>
        private void saveFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FileStream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Save file dialogue filter and options.
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile() as FileStream) != null)
                {
                    var bytes = Encoding.UTF8.GetBytes(this.textBox1.Text);
                    myStream.Write(bytes, 0, bytes.Length);
                    myStream.Close();
                }
            }
        }

        /// <summary>
        /// Load content from .txt file to textBox1.
        /// </summary>
        private void loadFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog.Filter = "Text Files (.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            openFileDialog.ShowDialog();

            // Open the selected file to read.
            System.IO.Stream fileStream = openFileDialog.OpenFile();
            this.textBox1.Text = new StreamReader(fileStream).ReadToEnd();
            fileStream.Close();
        }

        /// <summary>
        /// Loads first 50 fibonacci numbers.
        /// </summary>
        private void load50FibonacciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
        }

        /// <summary>
        /// Loads first 100 fibonacci numbers.
        /// </summary>
        private void load100FibonacciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
        }
    }
}
