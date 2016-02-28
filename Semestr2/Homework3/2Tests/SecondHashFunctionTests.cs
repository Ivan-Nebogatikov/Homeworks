using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem2.Tests
{
    [TestClass()]
    public class SecondHashFunctionTests
    {
        private AbstractHashFunction hashFunction;

        [TestInitialize()]
        public void Initialize()
        {
            hashFunction = new SecondHashFunction();
        }

        [TestMethod()]
        public void HashTest()
        {
            Assert.AreEqual(0, hashFunction.Hash("PPPPPPPPPPPPPPPPPPPPPp", 2));
            Assert.AreEqual(40, hashFunction.Hash("Hashshashshas", 54));
        }
    }
}