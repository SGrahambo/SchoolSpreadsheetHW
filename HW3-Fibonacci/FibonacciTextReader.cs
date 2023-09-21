// <copyright file="FibonacciTextReader.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace HW3_Fibonacci
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// prints the fibonacci number of a given input integer.
    /// </summary>
    public class FibonacciTextReader : System.IO.TextReader
    {
        private BigInteger firstNum = 0;
        private BigInteger secondNum = 0;
        private int countNum = 0;
        private int maxLines = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="max"> number of lines/fibonacy numbers to print. </param>
        public FibonacciTextReader(int max)
        {
            this.maxLines = max;
        }

        /// <summary>
        /// Returns the value of the fibonacci from the given integer.
        /// </summary>
        /// <returns> string of fibinacci number. </returns>
        public override string ReadLine()
        {
            BigInteger fib = 0;

            if (this.countNum == 0)
            {
                fib = 0;
                this.countNum++;
            }
            else if (this.countNum == 1)
            {
                this.firstNum = 0;
                this.secondNum = 1;
                fib = 1;
                this.countNum++;
            }
            else
            {
                fib = this.firstNum + this.secondNum;
                this.firstNum = this.secondNum;
                this.secondNum = fib;
            }

            return fib.ToString();
        }

        /// <summary>
        /// Calls ReadLine maxLines number of times and appends to stringbuilder.
        /// </summary>
        /// <returns> stringbuilder string. </returns>
        public override string ReadToEnd()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= this.maxLines; i++)
            {
                sb.Append(i + ": " + this.ReadLine());
                if (i < this.maxLines)
                {
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns the value of the fibonacci from the given integer.
        /// Turns out this method is useless for the assignment other than testing the logic.
        /// </summary>
        /// <param name="n"> input integer to calculate the fibonnaci from. </param>
        /// <returns> big int of the fibonnaci number. </returns>
        public static List<BigInteger> Fibonacci(int n)
        {
            List<BigInteger> fibList = new List<BigInteger>();
            BigInteger a = 0;
            BigInteger b = 0;
            BigInteger c = 0;

            for (int i = 0; i <= n; i++)
            {
                if (i == 1)
                {
                    c = 1;
                }
                else if (i > 1)
                {
                    a = b;
                    b = c;
                    c = a + b;
                }

                fibList.Add(c);
            }

            return fibList;
        }
    }
}