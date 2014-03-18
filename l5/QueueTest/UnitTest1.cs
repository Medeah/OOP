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

            Assert.IsTrue(queue.IsEmpty);
            Assert.IsFalse(queue.IsFull);

            queue.Enqueue(2);

            Assert.IsFalse(queue.IsFull);
            Assert.IsFalse(queue.IsEmpty);

            queue.Enqueue(3);

            Assert.IsTrue(queue.IsFull);
            Assert.IsFalse(queue.IsEmpty);

            Assert.AreEqual(2, queue.Head);
            Assert.AreEqual(3, queue.Tail);
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());

            Assert.IsTrue(queue.IsEmpty);
            Assert.IsFalse(queue.IsFull);
  
        }

        [TestMethod]
        public void MultipleQueueing()
        {
            MyQueue<int> queue = new MyQueue<int>(12);
            queue.Enqueue(1);
            for (int i = 0; i < 10; i++)
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
            Assert.IsFalse(sort.IsFull);
        }

        [TestMethod]
        public void OrderedPersons()
        {
            MyOrderedQueue<Person> persons = new MyOrderedQueue<Person>(3);

            persons.Enqueue(new Person { Age = 12, Name = "Frederik" });
            persons.Enqueue(new Person { Age = 8, Name = "Rasmus" });

            StringAssert.Equals("Rasmus", persons.Head);
            
            
        }
    }
}
