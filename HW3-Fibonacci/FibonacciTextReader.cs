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
        /// <summary>
        /// Returns the value of the fibonacci from the given integer.
        /// </summary>
        /// <param name="n"> input integer to calculate the fibonnaci from. </param>
        /// <returns> big int of the fibonnaci number. </returns>
        public static BigInteger Fibonacci(int n)
        {
            BigInteger a = 0;
            BigInteger b = 0;
            BigInteger c = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    c = 1;
                }
                else
                {
                    a = b;
                    b = c;
                    c = a + b;
                }
            }

            return c;
        }
    }
}