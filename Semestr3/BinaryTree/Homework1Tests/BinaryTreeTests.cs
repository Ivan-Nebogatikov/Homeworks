using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework1.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void AddTest()
        {
            var tree = new BinaryTree<int>();
            Assert.IsTrue(tree.IsEmpty());
            tree.Add(3);
            Assert.IsFalse(tree.IsEmpty());
            tree.Add(1);
            tree.Add(4);
            Assert.IsTrue(tree.Contains(3));
            Assert.IsTrue(tree.Contains(1));
            Assert.IsTrue(tree.Contains(4));
            Assert.IsFalse(tree.Contains(2));
            Assert.IsFalse(tree.IsEmpty());
        }

        [TestMethod]
        public void DeleteTest()
        {
            var tree = new BinaryTree<float>();
            tree.Add(4.21f);
            tree.Add(421);
            tree.Add(42);
            tree.Add(1);
            tree.Add(1000.500f);
            tree.Delete(4.21f);
            Assert.IsFalse(tree.Contains(4.21f));
            Assert.IsTrue(tree.Contains(421));
            Assert.IsTrue(tree.Contains(42));
            Assert.IsTrue(tree.Contains(1));
            tree.Delete(421);
            Assert.IsFalse(tree.Contains(421));
            Assert.IsTrue(tree.Contains(1));
            tree.Delete(1);
            Assert.IsFalse(tree.Contains(1));
            Assert.IsFalse(tree.Contains(421));
            Assert.IsTrue(tree.Contains(42));
            tree.Delete(42);
            Assert.IsFalse(tree.Contains(42));
            Assert.IsTrue(tree.Contains(1000.500f));
            tree.Delete(1000.500f);
            Assert.IsFalse(tree.Contains(1000.500f));
            Assert.IsTrue(tree.IsEmpty());
        }

        [TestMethod]
        public void DeleteTest2()
        {
            var tree = new BinaryTree<int>();
            tree.Add(4);
            tree.Add(1);
            tree.Add(3);
            tree.Add(2);
            tree.Add(5);
            tree.Delete(4);
            Assert.IsTrue(tree.Contains(3));
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            var tree = new BinaryTree<string>();
            tree.Add("lalal");
            tree.Add("dsa");
            tree.Add("ololo");
            tree.Add("tree.Add");
            tree.Add("a");
            tree.Add("zzzzzzzzzzzzzzzzzzzzzzzzz");
            int count = 0;
            foreach (var element in tree)
            {
                ++count;
                Assert.IsTrue(tree.Contains(element));
            }
            Assert.AreEqual(6, count);
        }
    }
}