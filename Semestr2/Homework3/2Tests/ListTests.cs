using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem2.Tests
{
    [TestClass()]
    public class ListTests
    {
        private List list;

        [TestInitialize()]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod()]
        public void AddTest()
        {
            list.Add("1");
            Assert.IsFalse(list.GetLength() == 0);
        }

        [TestMethod()]
        public void AnotherAddTest()
        {
            list.Add("1");
            list.Add("2");
            list.Add("-4");
            Assert.AreEqual(3, list.GetLength());
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            list.Add("2");
            list.Add("-4");
            Assert.AreEqual(1, list.IndexOf("2"));
        }

        [TestMethod()]
        public void IndexOfNotExistedElementTest()
        {
            list.Add("2");
            list.Add("-4");
            Assert.AreEqual(-1, list.IndexOf("-1000"));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            list.Add("2");
            list.Add("-4");
            Assert.IsTrue(list.Remove("-4"));
            Assert.IsTrue(list.Remove("2"));
        }

        [TestMethod()]
        public void RemoveFromEmptyListTest()
        {
            Assert.IsFalse(list.Remove("-4"));
        }

        [TestMethod()]
        public void GetLengthTest()
        {
            list.Add("1");
            list.Add("2");
            list.Add("-4");
            list.Remove("-100");
            list.Remove("2");
            Assert.AreEqual(2, list.GetLength());
        }

        [TestMethod()]
        public void GetElementTest()
        {
            list.Add("8");
            list.Add("800");
            list.Add("555");
            list.Add("3");
            list.Add("5");
            list.Add("35");
            Assert.AreEqual("35", list.GetElement(0));
            Assert.AreEqual("555", list.GetElement(3));
            Assert.AreEqual("", list.GetElement(80));
        }

        [TestMethod()]
        public void TestForAllMethods()
        {
            list.Add("8");
            list.Add("800");
            Assert.AreEqual(2, list.GetLength());
            list.Add("555");
            list.Remove("800");
            Assert.AreEqual("8", list.GetElement(1));
            Assert.AreEqual("", list.GetElement(-8));
            list.Add("3");
            list.Add("5");
            list.Add("35");
            Assert.AreEqual(2, list.IndexOf("3"));
        }
    }
}