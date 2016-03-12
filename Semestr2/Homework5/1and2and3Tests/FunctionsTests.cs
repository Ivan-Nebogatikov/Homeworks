using Problem1and2and3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem1and2and3.Tests
{
    [TestClass()]
    public class FunctionsTests
    {
        private List list;

        [TestInitialize()]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod()]
        public void MapTest()
        {
            list.Add(3);
            list.Add(30);
            list.Add(-8);
            list = Functions.Map(list, x => x * 2);
            Assert.AreEqual(-16, list.GetElement(0));
            Assert.AreEqual(60, list.GetElement(1));
            Assert.AreEqual(6, list.GetElement(2));
        }

        [TestMethod()]
        public void FilterTest()
        {
            list.Add(0);
            list.Add(50);
            list.Add(-2);
            list.Add(-9999);
            list = Functions.Filter(list, x => x >= 0);
            Assert.AreEqual(2, list.GetLength());
            Assert.AreEqual(0, list.GetElement(0));
            Assert.AreEqual(50, list.GetElement(1));
        }

        [TestMethod()]
        public void FoldTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(6, Functions.Fold(list, 1, (acc, elem) => acc * elem));
        }

        [TestMethod()]
        public void ComplexTest()
        {
            list.Add(1);
            list.Add(22);
            list.Add(-3);
            list.Add(1);
            list.Add(0);
            list.Add(222);
            list.Add(1);
            list.Add(-79);
            list.Add(38);

            list = Functions.Map(list, x => x - 4);
            Assert.AreEqual(9, list.GetLength());
            Assert.AreEqual(34, list.GetElement(0));
            Assert.AreEqual(-83, list.GetElement(1));
            Assert.AreEqual(-3, list.GetElement(2));
            Assert.AreEqual(218, list.GetElement(3));
            Assert.AreEqual(-4, list.GetElement(4));
            Assert.AreEqual(-3, list.GetElement(5));
            Assert.AreEqual(-7, list.GetElement(6));
            Assert.AreEqual(18, list.GetElement(7));
            Assert.AreEqual(-3, list.GetElement(8));

            list = Functions.Filter(list, x => x % 3 == 0);
            Assert.AreEqual(4, list.GetLength());
            Assert.AreEqual(-3, list.GetElement(0));
            Assert.AreEqual(18, list.GetElement(1));
            Assert.AreEqual(-3, list.GetElement(2));
            Assert.AreEqual(-3, list.GetElement(3));

            Assert.AreEqual(991, Functions.Fold(list, 1000, (acc, elem) => acc - elem));
        }
    }
}