using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using l5;

namespace QueueTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void SingleQueue()
        {
            MyQueue<int> queue = new MyQueue<int>(1);
            queue.Enqueue(1);
            
            Assert.AreEqual(1, queue.Dequeue());
            
        }

        [TestMethod]
        public void SimpleQueueing()
        {
            MyQueue<int> queue = new MyQueue<int>(2);

            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Dequeue());
            queue.Enqueue(2);
            queue.Enqueue(3);
            Assert.IsTrue(queue.IsFull);
            Assert.AreEqual(2, queue.Head);
            Assert.AreEqual(3, queue.Tail);
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.IsTrue(queue.IsEmpty);
  
        }

        [TestMethod]
        public void MultipleQueueing()
        {
            MyQueue<int> queue = new MyQueue<int>(22);
            queue.Enqueue(1);
            for (int i = 0; i < 20; i++)
            {
                queue.Enqueue(2);
                queue.Enqueue(3);
                queue.Dequeue();
            }
            Assert.AreEqual(3, queue.Dequeue());

            try
            {
                while (!queue.IsEmpty)
                {
                    queue.Dequeue();
                }
            }
            catch (QueueException ex)
            {
                Assert.Fail("Can not empty the queue: " + ex.Message);
            }
            Assert.IsTrue(queue.IsEmpty);
            

        }

        [TestMethod]
        public void ShouldThrowWhenFull()
        {
            MyQueue<int> queue = new MyQueue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);

            try
            {
                queue.Enqueue(3);
            }
            catch (QueueFullException _)
            {
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void ShouldThrowWhenEmpty()
        {
            MyQueue<int> queue = new MyQueue<int>(2);

            try
            {
                queue.Dequeue();
            }
            catch (QueueException _)
            {
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void OrderedQueue()
        {
            MyOrderedQueue<int> sort = new MyOrderedQueue<int>(3);

            sort.Enqueue(20);
            sort.Enqueue(3);
            sort.Enqueue(6);
            Assert.IsTrue(sort.IsFull);
            Assert.AreEqual(20, sort.Tail);
            Assert.AreEqual(3, sort.Dequeue());
        }

        //TODO: tesing  persons can be inserted into your MyOrderedQueue

    }
}
