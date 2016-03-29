using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem1.Tests
{
    [TestClass()]
    public class PriorityQueueTests
    {
        private PriorityQueue priorityQueue;

        [TestInitialize()]
        public void Initialize()
        {
            priorityQueue = new PriorityQueue();
        }

        [TestMethod()]
        public void PriorityQueueTest()
        {
            priorityQueue.Enqueue(10, 1);
            priorityQueue.Enqueue(20, 2);
            Assert.AreEqual(20, priorityQueue.Dequeue());
            Assert.AreEqual(10, priorityQueue.Dequeue());
            Assert.IsTrue(priorityQueue.IsEmpty());
        }

        [TestMethod()]
        [ExpectedException(typeof(OutOfPriorityNumberException))]
        public void WrongPriorityTest()
        {
            priorityQueue = new PriorityQueue(40);
            priorityQueue.Enqueue(20, 777);
        }

        [TestMethod()]
        [ExpectedException(typeof(OutOfPriorityNumberException))]
        public void WrongPriorityInConsturctorTest()
        {
            priorityQueue = new PriorityQueue(-40);
        }

        [TestMethod()]
        [ExpectedException(typeof(EmptyQueueException))]
        public void DequeueFromEmptyQueueTest()
        {
            priorityQueue.Enqueue(10, 1);
            priorityQueue.Dequeue();
            priorityQueue.Dequeue();
        }

        [TestMethod()]
        public void GoodTest()
        {
            priorityQueue.Enqueue(10, 1);
            priorityQueue.Enqueue(20, 1);
            priorityQueue.Enqueue(34, 1);
            priorityQueue.Enqueue(-10, 1);
            Assert.AreEqual(10, priorityQueue.Dequeue());
            priorityQueue.Enqueue(70, 0);
            priorityQueue.Enqueue(-1000, 87);
            Assert.AreEqual(-1000, priorityQueue.Dequeue());
            Assert.AreEqual(20, priorityQueue.Dequeue());
        }

        [TestMethod()]
        public void ComplexTest()
        {
            priorityQueue.Enqueue(10, 99);
            priorityQueue.Enqueue(20, 21);
            priorityQueue.Enqueue(34, 4);
            priorityQueue.Enqueue(-10, 1);
            priorityQueue.Enqueue(10, 99);
            Assert.AreEqual(10, priorityQueue.Dequeue());
            Assert.AreEqual(10, priorityQueue.Dequeue());
            priorityQueue.Enqueue(1000, 20);
            Assert.AreEqual(20, priorityQueue.Dequeue());
            Assert.IsFalse(priorityQueue.IsEmpty());
            Assert.AreEqual(1000, priorityQueue.Dequeue());
            Assert.AreEqual(34, priorityQueue.Dequeue());
            Assert.AreEqual(-10, priorityQueue.Dequeue());
            Assert.IsTrue(priorityQueue.IsEmpty());
        }
    }
}