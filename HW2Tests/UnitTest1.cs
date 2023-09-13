using NUnit.Framework;
using System.Collections.Generic;
using HW2_WinForms;

namespace HW2_WinForms
{
    public class Tests
    {

        static int[] a0 = { }; // 0 distinct
        static int[] a1 = { 0, 99, 87, 99, 50, 50, 50, 876, 888, 963, 888, 8989, 20000, 0, 1 }; // 10 distinct

        List<int> list0 = new List<int>(a0);
        List<int> list1 = new List<int>(a1);

        [SetUp]
        public void Setup()
        {
            
        }

        

        [Test]
        public void TestHashDistinct()
        {
            Assert.That(Distinct.HashDistinct(list0), Is.EqualTo(0));
            Assert.That(Distinct.HashDistinct(list1), Is.EqualTo(10));
        }

        [Test]
        public void TestO1Distinct()
        {
            Assert.That(Distinct.O1Distinct(0, 20000, list0), Is.EqualTo(0));
            Assert.That(Distinct.O1Distinct(0, 20000, list1), Is.EqualTo(10));
        }

        [Test]
        public void SortDistinct()
        {
            Assert.That(Distinct.SortDistinct(list0), Is.EqualTo(0));
            Assert.That(Distinct.SortDistinct(list1), Is.EqualTo(10));
        }
    }
}