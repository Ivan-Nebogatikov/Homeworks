using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Problem2.Tests
{
    [TestClass()]
    public class HashTableTests
    {
        private HashTable hashTable1;
        private HashTable hashTable2;
        private HashTable hashTable3;
        private const int size = 100;

        [TestInitialize()]
        public void Initialize()
        {
            hashTable1 = new HashTable(size, new FirstHashFunction());
            hashTable2 = new HashTable(size, new SecondHashFunction());
            hashTable3 = new HashTable(size, new ThirdHashFunction());
        }

        [TestMethod()]
        public void AddTest()
        {
            hashTable1.Add("dsadas");
            hashTable2.Add("dsadas");
            hashTable3.Add("dsadas");
            hashTable2.Add("dasfwfefea");
        }

        [TestMethod()]
        public void DeleteTest()
        {
            hashTable1.Add("first");
            hashTable2.Add("second");
            Assert.IsTrue(hashTable1.Delete("first"));
            Assert.IsFalse(hashTable1.Delete("first"));
            Assert.IsFalse(hashTable2.Delete("first"));
            Assert.IsFalse(hashTable3.Delete("fds"));
        }

        [TestMethod()]
        public void ExistTest()
        {
            hashTable3.Add("first");
            hashTable2.Add("second");
            Assert.IsTrue(hashTable3.Exist("first"));
            Assert.IsTrue(hashTable3.Delete("first"));
            Assert.IsFalse(hashTable3.Exist("first"));
        }

        [TestMethod()]
        public void TestForAllMethods()
        {
            Assert.IsFalse(hashTable3.Exist("ff"));
            hashTable3.Add("first");
            hashTable2.Add("second");
            hashTable1.Add("third");
            Assert.IsFalse(hashTable2.Delete("ff"));
            hashTable3.Add("gg");
            hashTable2.Add("aa");
            hashTable1.Add("ff");
            Assert.IsFalse(hashTable1.Delete("aa"));
            Assert.IsTrue(hashTable2.Delete("aa"));
            Assert.IsTrue(hashTable1.Exist("ff"));
            Assert.IsTrue(hashTable3.Delete("first"));
            Assert.IsFalse(hashTable3.Exist("first"));
        }
    }
}