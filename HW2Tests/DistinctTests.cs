// <copyright file="DistinctTests.cs" company="Stephen Graham - 011706998">
// Copyright (c) Stephen Graham - 011706998. All rights reserved.
// </copyright>

namespace HW2_WinForms
{
    using System.Collections.Generic;
    using HW2_WinForms;
    using NUnit.Framework;

    /// <summary>
    /// Test methods of Distinct class.
    /// </summary>
    public class DistinctTests
    {
        private static int[] a0 = { }; // 0 distinct
        private static int[] a1 = { 0, 99, 87, 99, 50, 50, 50, 876, 888, 963, 888, 8989, 20000, 0, 1 }; // 10 distinct

        private List<int> list0 = new List<int>(a0);
        private List<int> list1 = new List<int>(a1);

        /// <summary>
        /// Tests HashDistinct method.
        /// </summary>
        [Test]
        public void TestHashDistinct()
        {
            Assert.That(Distinct.HashDistinct(this.list0), Is.EqualTo(0));
            Assert.That(Distinct.HashDistinct(this.list1), Is.EqualTo(10));
        }

        /// <summary>
        /// Tests O1Distinct method.
        /// </summary>
        [Test]
        public void TestO1Distinct()
        {
            Assert.That(Distinct.O1Distinct(0, 20000, this.list0), Is.EqualTo(0));
            Assert.That(Distinct.O1Distinct(0, 20000, this.list1), Is.EqualTo(10));
        }

        /// <summary>
        /// Tests SortDistinct method.
        /// </summary>
        [Test]
        public void SortDistinct()
        {
            Assert.That(Distinct.SortDistinct(this.list0), Is.EqualTo(0));
            Assert.That(Distinct.SortDistinct(this.list1), Is.EqualTo(10));
        }
    }
}