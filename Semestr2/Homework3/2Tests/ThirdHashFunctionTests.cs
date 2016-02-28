using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem2.Tests
{
    [TestClass()]
    public class ThirdHashFunctionTests
    {
        private AbstractHashFunction hashFunction;

        [TestInitialize()]
        public void Initialize()
        {
            hashFunction = new ThirdHashFunction();
        }

        [TestMethod()]
        public void HashTest()
        {
            Assert.AreEqual(112, hashFunction.Hash("opopoopop", 222));
            Assert.AreEqual(4, hashFunction.Hash("f", 7));
        }
    }
}