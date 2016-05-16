using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem1and2.Tests
{
    [TestClass()]
    public class SetTests
    {
        [TestMethod()]
        public void SetTest()
        {
            var set = new Set<int>();
            set.Add(2);
            Assert.IsTrue(set.Contains(2));
            set.Delete(2);
            Assert.IsFalse(set.Contains(2));
        }

        [TestMethod()]
        public void IntersectionTest()
        {
            var firstSet = new Set<string>();
            var secondSet = new Set<string>();
            firstSet.Add("lol");
            firstSet.Add("olo");
            firstSet.Add("lol");
            secondSet.Add("ololo");
            secondSet.Add("lol");
            var newSet = firstSet.Intersection(secondSet);
            Assert.IsTrue(newSet.Contains("lol"));
            Assert.IsFalse(newSet.Contains("ololo"));
            Assert.IsTrue(firstSet.Contains("olo"));
            Assert.IsTrue(secondSet.Contains("ololo"));
        }

        [TestMethod()]
        public void UnionTest()
        {
            var firstSet = new Set<double>();
            var secondSet = new Set<double>();
            firstSet.Add(2.2);
            firstSet.Add(20.1415926);
            firstSet.Add(2.2);
            secondSet.Add(10);
            secondSet.Add(2.2);
            var newSet = firstSet.Union(secondSet);
            Assert.IsTrue(newSet.Contains(2.2));
            Assert.IsTrue(newSet.Contains(10));
            Assert.IsTrue(newSet.Contains(20.1415926));
        }

        [TestMethod()]
        public void ComplexTest()
        {
            var firstSet = new Set<int>();
            var secondSet = new Set<int>();
            var thirdSet = new Set<int>();
            for (int i = 0; i <= 100; ++i)
                firstSet.Add(i);
            for (int i = -50; i <= 50; ++i)
                secondSet.Add(i);
            for (int i = -50; i <= 100; i += 2)
                thirdSet.Add(i);
            var newSet = firstSet.Union(secondSet);
            for (int i = -50; i <= 100; ++i)
                Assert.IsTrue(newSet.Contains(i));
            newSet = newSet.Intersection(thirdSet);
            for (int i = -50; i <= 100; i += 2)
                Assert.IsTrue(newSet.Contains(i));
            newSet = newSet.Intersection(firstSet);
            for (int i = 0; i <= 100; i += 2)
                Assert.IsTrue(newSet.Contains(i));
            for (int i = -50; i < 0; i += 2)
                Assert.IsFalse(newSet.Contains(i));
        }
    }
}