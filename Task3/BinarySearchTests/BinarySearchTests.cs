using System;
using System.Text;
using BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearchComparableTypeTestMethod()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            int expected = 3;
            int actual = array.BinarySearch(4);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void BinarySearchCustomComparerTestMethod()
        {
            var array = new[] { 6, 5, 4, 3, 2, 1 };
            int expected = 2;
            int actual = array.BinarySearch(4, new IntCustomComparer());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearchCustomComparerNullTypeComparableTestMethod()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            int expected = 3;
            Func<int, int, int> comparison = null;

            int actual = array.BinarySearch(4, comparison);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearchComparisonTestMethod()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            int expected = 3;
            int actual = array.BinarySearch(4, (firstInt, secondInt) =>
            {
                if (firstInt > secondInt) return 1;
                if (firstInt < secondInt) return -1;
                return 0;
            });
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void BinarySearchCustomComparerNullTypeNotComparableTestMethod()
        {
            var array = new[] { new StringBuilder("1"), new StringBuilder("2"), new StringBuilder("3")};
            int expected = 1;
            StringBuilderCustomComparer comparer = null;
            int actual = array.BinarySearch(new StringBuilder("1"), comparer);
            Assert.AreEqual(expected, actual);
        }


    }
}
