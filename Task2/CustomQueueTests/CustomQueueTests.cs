using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomQueue;

namespace CustomQueueTests
{
    [TestClass]
    public class CustomQueueTests
    {
        [TestMethod]
        public void EnqueueTestMethod()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            var expected = new[] { 10, 20, 30, 40, 50 };

            var actual = queue.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DequeueTestMethod()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            var expectedItem = 10;
            var expectedQueue = new[] { 20, 30, 40, 50 };

            var actualItem = queue.Dequeue();
            var actualQueue = queue.ToArray();

            bool actual = actualQueue.SequenceEqual(expectedQueue) && (actualItem == expectedItem);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void PeekTestMethod()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            var expectedItem = 10;
            var expectedQueue = new[] { 10, 20, 30, 40, 50 };

            var actualItem = queue.Peek();
            var actualQueue = queue.ToArray();

            bool actual = actualQueue.SequenceEqual(expectedQueue) && (actualItem == expectedItem);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void ClearTestMethod()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            var expectedQueue = new int[] { };

            queue.Clear();
            var actualQueue = queue.ToArray();

            CollectionAssert.AreEqual(expectedQueue, actualQueue);
        }


    }
}
