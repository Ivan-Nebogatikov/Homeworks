using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.Tests
{
    [TestClass()]
    public class UniqueListTests
    {
        private UniqueList list;

        [TestInitialize()]
        public void Initialize()
        {
            list = new UniqueList();
        }

        [TestMethod()]
        public void AddTest()
        {
            list.Add(4);
            list.Add(7);
        }

        [TestMethod()]
        [ExpectedException(typeof(ExistingNumberException))]
        public void AddExceptionTest()
        {
            list.Add(4);
            list.Add(7);
            list.Add(5);
            list.Add(7);
        }

        [TestMethod()]
        [ExpectedException(typeof(RemoveNotExistingElementException))]
        public void DeleteExceptionTest()
        {
            list.Add(4);
            list.Add(7);
            list.Add(5);
            list.Add(77);
            list.Remove(10);
        }

        [TestMethod()]
        [ExpectedException(typeof(OutOfBoundsOfListException))]
        public void IndexExceptionTest()
        {
            list.Add(4);
            list.Add(7);
            list.Add(5);
            list.Add(50);
            list.GetElement(100);
        }

        [TestMethod()]
        [ExpectedException(typeof(ElementDoesNotFoundInListException))]
        public void ElementNotFoundExceptionTest()
        {
            list.Add(4);
            list.Add(7);
            list.Add(5);
            list.Add(50);
            list.IndexOf(567);
        }

        [TestMethod()]
        public void GoodTest()
        {
            list.Add(4);
            list.Add(7);
            list.Add(5);
            list.Add(50);
            Assert.AreEqual(0, list.IndexOf(50));
            Assert.AreEqual(4, list.GetLength());
            list.Remove(7);
            Assert.AreEqual(3, list.GetLength());
            Assert.AreEqual(2, list.IndexOf(4));
        }
    }
}