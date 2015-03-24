using System;
using System.Collections.Generic;
using CustomList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomListUnitTest
    {

        private int[] testArray = { 1, 2, 3, 5, 6, 7, 8, 9, 9, 10 };
        [TestMethod]
        public void TestEnumeratorWithFilterOnlyEvenNumbers()
        {
            var source = new CustomList<int>(testArray);
            var expected = new[] { 2, 6, 8, 10 };
            var actual = new List<int>();
            foreach (var element in source.GetElement(x => (x % 2) == 0))
            {
                actual.Add(element);
            }

            CollectionAssert.AreEqual(expected, actual.ToArray());
        }
    }
}
