using NUnit.Framework;
using HW3_Fibonacci;
using System.Numerics;

namespace HW3_Fibonacci.Tests
{
    public class FibonacciTests
    {
        [SetUp]
        public void Setup()
        {
        }
        //BigInteger f0 = new BigInteger(0);
        //BigInteger f1 = new BigInteger(1);
        //BigInteger f2 = new BigInteger(1);
        //BigInteger f3 = new BigInteger(2);
        //BigInteger f4 = new BigInteger(3);
        //BigInteger f5 = new BigInteger(5);
        //BigInteger f10 = new BigInteger(55);
        //BigInteger f20 = new BigInteger(6765);
        //BigInteger f50 = new BigInteger(12586269025);
        //BigInteger f100 = new BigInteger(354224848179261915075);

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
        public void Test1(int a, string b)
        {
            BigInteger BigInt = BigInteger.Parse(b);
            Assert.That(FibonacciTextReader.Fibonacci(a), Is.EqualTo(BigInt));
        }
    }
}