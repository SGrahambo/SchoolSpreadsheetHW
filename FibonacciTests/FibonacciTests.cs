using NUnit.Framework;
using HW3_Fibonacci;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace HW3_Fibonacci.Tests
{
    public class FibonacciTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, "0")]
        [TestCase(2, "1")]
        [TestCase(3, "1")]
        [TestCase(4, "2")]
        [TestCase(5, "3")]
        [TestCase(6, "5")]
        [TestCase(11, "55")]
        [TestCase(16, "610")]
        [TestCase(51, "12586269025")]
        [TestCase(101, "354224848179261915075")]
        public void FibonacciTextReaderTest(int a, string b)
        {
            FibonacciTextReader ftr = new FibonacciTextReader(a);
            string s = ftr.ReadToEnd();
            s = s.Split(' ').Last();
            Assert.That(s, Is.EqualTo(b));
        }

        [TestCase(0, "0")]
        [TestCase(1, "1")]
        [TestCase(2, "1")]
        [TestCase(3, "2")]
        [TestCase(4, "3")]
        [TestCase(5, "5")]
        [TestCase(10, "55")]
        [TestCase(15, "610")]
        [TestCase(50, "12586269025")]
        [TestCase(100, "354224848179261915075")]
        public void FibonacciTest(int a, string b)
        {
            BigInteger bigInt = BigInteger.Parse(b);
            Assert.That(FibonacciTextReader.Fibonacci(a).LastOrDefault(), Is.EqualTo(bigInt));
        }
    }
}