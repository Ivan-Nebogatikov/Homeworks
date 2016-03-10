using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem1.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        [TestMethod()]
        public void BinaryTreeTest()
        {
            BinaryTree binaryTree = new BinaryTree("(+ 155544 152)");
            Assert.AreEqual(155696, binaryTree.Calculate());
        }

        [TestMethod()]
        public void HardBinaryTreeTest()
        {
            BinaryTree binaryTree = new BinaryTree("(+ (+ 2 (- 4 (/ 30 2))) (* 7 (- 77 7))");
            Assert.AreEqual(481, binaryTree.Calculate());
        }

        [TestMethod()]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void DivisionByZeroTest()
        {
            BinaryTree binaryTree = new BinaryTree("(+ (+ 333 (/ 4 (- 30 (+ 15 15)))) 3)");
            binaryTree.Calculate();
        }
    }
}