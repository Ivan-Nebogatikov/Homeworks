using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem1and2.Tests
{
    [TestClass()]
    public class ListStackTests
    {
        [TestMethod()]
        public void ListStackTest()
        {
            var stack = new ListStack<int>();
            stack.Push(0);
            stack.Push(10);
            stack.Push(-10);
            Assert.AreEqual(-10, stack.Pop());
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(10, stack.Pop());
            Assert.AreEqual(0, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod()]
        [ExpectedException(typeof(EmptyStackException))]
        public void EmptyStackExceptionTest()
        {
            var stack = new ListStack<int>();
            stack.Push(1010101);
            stack.Pop();
            stack.Pop();
        }

        [TestMethod()]
        public void ObjectStackTest()
        {
            var stack = new ListStack<object>();
            stack.Push(1010101);
            stack.Push(-Math.PI);
            stack.Push("ya");
            Assert.AreEqual("ya", stack.Pop());
            Assert.AreEqual(-Math.PI, stack.Pop());
            Assert.AreEqual(1010101, stack.Pop());
        }
    }
}