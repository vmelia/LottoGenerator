using LottoGenerator.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoGenerator.UnitTests
{
    [TestClass]
    public class CharacterEvaluatorTests
    {
        [TestMethod]
        public void AGeneratesOne()
        {
            var number = CharacterEvaluator.Convert('a');

            Assert.AreEqual(1, number);
        }
        
        [TestMethod]
        public void ZGeneratesTwentySix()
        {
            var number = CharacterEvaluator.Convert('z');

            Assert.AreEqual(26, number);
        }

        [TestMethod]
        public void CapitalAGeneratesOne()
        {
            var number = CharacterEvaluator.Convert('A');

            Assert.AreEqual(1, number);
        }
    }
}
