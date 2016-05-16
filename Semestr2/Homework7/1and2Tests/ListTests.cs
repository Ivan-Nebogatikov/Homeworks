using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem1and2.Tests
{
    [TestClass()]
    public class ListTests
    {
        [TestMethod()]
        public void FirstListTest()
        {
            var list = new List<int>();
            list.Add(10);
            Assert.IsTrue(list.Contains(10));
            list.Remove(10);
            Assert.AreEqual(0, list.GetLength());
        }

        [TestMethod()]
        public void DoubleListTest()
        {
            var list = new List<double>();
            list.Add(10.1213131);
            list.Add(-4315.41412);
            Assert.IsFalse(list.Contains(10));
            Assert.AreEqual(10.1213131, list.GetElement(1));
            Assert.AreEqual(0, list.IndexOf(-4315.41412));
        }

        [TestMethod()]
        [ExpectedException(typeof(RemoveNotExistingElementException))]
        public void AnotherListTest()
        {
            var list = new List<List<Tuple<string, bool>>>();
            list.Add(new List<Tuple<string, bool>>());
            list.Add(new List<Tuple<string, bool>>());
            list.Add(new List<Tuple<string, bool>>());
            list.GetElement(0).Add(new Tuple<string, bool>("First", true));
            list.GetElement(2).Add(new Tuple<string, bool>("First", false));
            list.GetElement(2).Add(new Tuple<string, bool>("RoRoRo", false));
            Assert.AreEqual(new Tuple<string, bool>("First", false), list.GetElement(2).GetElement(1));
            Assert.AreEqual(3, list.GetLength());
            list.GetElement(2).Remove(new Tuple<string, bool>("RoRoRo", false));
            Assert.AreEqual(new Tuple<string, bool>("First", false), list.GetElement(2).GetElement(0));
            Assert.AreEqual(3, list.GetLength());
            Assert.AreEqual(0, list.GetElement(1).GetLength());
            Assert.AreEqual(1, list.GetElement(2).GetLength());
            list.GetElement(1).Remove(new Tuple<string, bool>("First", true));
        }

        [TestMethod()]
        public void EnumeratorTest()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; ++i)
                list.Add(i);
            int sum = 0;
            foreach (int value in list)
                sum += value;
            Assert.AreEqual(45, sum);
        }
    }
}