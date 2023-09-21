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
            //List<BigInteger> last = FibonacciTextReader.Fibonacci(a);
            //List<BigInteger> fibList = new List<BigInteger>(FibonacciTextReader.Fibonacci(a));

            //Assert.That(FibonacciTextReader.Fibonacci(a), Is.EqualTo(bigInt));
            Assert.That(FibonacciTextReader.Fibonacci(a).LastOrDefault(), Is.EqualTo(bigInt));
        }
    }
}