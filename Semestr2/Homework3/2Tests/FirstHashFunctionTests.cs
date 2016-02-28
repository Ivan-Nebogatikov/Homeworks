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
    public class FirstHashFunctionTests
    {
        private AbstractHashFunction hashFunction;

        [TestInitialize()]
        public void Initialize()
        {
            hashFunction = new FirstHashFunction();
        }

        [TestMethod()]
        public void HashTest()
        {
            Assert.AreEqual(16, hashFunction.Hash("true", 100));
            Assert.AreEqual(18, hashFunction.Hash("Hashshashshas", 54));
        }
    }
}