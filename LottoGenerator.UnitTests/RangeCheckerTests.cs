using LottoGenerator.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoGenerator.UnitTests
{
    [TestClass]
    public class RangeCheckerTests
    {
        [TestMethod]
        public void OneConvertsOk()
        {
            Assert.AreEqual(1, RangeChecker.Process(1));
        }
        
        [TestMethod]
        public void FortyNineConvertsOk()
        {
            Assert.AreEqual(49, RangeChecker.Process(49));
        }

        [TestMethod]
        public void FiftyConvertsToOne()
        {
            Assert.AreEqual(1, RangeChecker.Process(50));
        }
        
        [TestMethod]
        public void NinetyEightConvertsToFortyNine()
        {
            Assert.AreEqual(49, RangeChecker.Process(98));
        }
        
        [TestMethod]
        public void NinetyNineConvertsToOne()
        {
            Assert.AreEqual(1, RangeChecker.Process(99));
        }
    }
}
