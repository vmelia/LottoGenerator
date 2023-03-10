using LottoGenerator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoGenerator.UnitTests
{
    [TestClass]
    public class GeneratorStringTests
    {
        private static Generator _generator;

        [TestMethod]
        public void NullStringGeneratesNoNumbers()
        {
            var numbers = _generator.Convert(null);

            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void EmptyStringGeneratesNoNumbers()
        {
            var numbers = _generator.Convert(string.Empty);

            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void OneAGeneratesOne()
        {
            var numbers = _generator.Convert("a");

            Assert.AreEqual(1, numbers.Count);
            Assert.AreEqual(1, numbers[0]);
        }

        [TestMethod]
        public void AandAGenerateCorrectly()
        {
            var numbers = _generator.Convert("aa");

            Assert.AreEqual(2, numbers.Count);
            Assert.AreEqual(1, numbers[0]);
            Assert.AreEqual(2, numbers[1]);
        }

        [TestMethod]
        public void ZandWGenerateCorrectly()
        {
            var numbers = _generator.Convert("zw");

            Assert.AreEqual(26, numbers[0]);
            Assert.AreEqual(49, numbers[1]);
        }

        [TestMethod]
        public void ZandXGenerateCorrectly()
        {
            var numbers = _generator.Convert("zx");

            Assert.AreEqual(26, numbers[0]);
            Assert.AreEqual(1, numbers[1]);
        }

        [TestMethod]
        public void DuplicatesHandleCorrectly()
        {
            var numbers = _generator.Convert("zwz");

            Assert.AreEqual(26, numbers[0]);    //'z'.
            Assert.AreEqual(49, numbers[1]);    //'z' + 'w' = 26 + 23 = 49.
            Assert.AreEqual(3, numbers[2]);     //49 + 26 = 75 => 26. This is used so add increment (26) = 52 => 3.
        }
        
        [TestMethod]
        public void GeneratesFromRibisiCorrectly()
        {
            var numbers = _generator.Convert("ribisi");

            Assert.AreEqual(6, numbers.Count);
        }

        [TestMethod]
        public void GeneratesFromGhmommCorrectly()
        {
            var numbers = _generator.Convert("ghmomm");

            Assert.AreEqual(07, numbers[0]);    //g
            Assert.AreEqual(15, numbers[1]);    //h 
            Assert.AreEqual(28, numbers[2]);    //m
            Assert.AreEqual(43, numbers[3]);    //o
            Assert.AreEqual(20, numbers[4]);    //m
            Assert.AreEqual(33, numbers[5]);    //m
        }

        [TestMethod]
        public void GeneratesFromZeroCatCorrectly()
        {
            var numbers = _generator.Convert("zerocat");

            Assert.AreEqual(26, numbers[0]);    //z 26  26  26
            Assert.AreEqual(31, numbers[1]);    //e 5   31  31
            Assert.AreEqual(49, numbers[2]);    //r 18  49  49
            Assert.AreEqual(15, numbers[3]);    //o 15  64  15
            Assert.AreEqual(18, numbers[4]);    //c 3   18  18
            Assert.AreEqual(19, numbers[5]);    //a 1   19  19
            Assert.AreEqual(39, numbers[6]);    //t 20  39  39
        }

        [TestMethod]
        public void GeneratesFromGeorgiaCorrectly()
        {
            var numbers = _generator.Convert("georgia");

            Assert.AreEqual(07, numbers[0]);    //g
            Assert.AreEqual(12, numbers[1]);    //e 
            Assert.AreEqual(27, numbers[2]);    //o
            Assert.AreEqual(45, numbers[3]);    //r
            Assert.AreEqual(03, numbers[4]);    //g
            Assert.AreEqual(21, numbers[5]);    //i
            Assert.AreEqual(22, numbers[6]);    //a
        }

        [TestMethod]
        public void SpacesAreRemoved()
        {
            var numbers = _generator.Convert("a a");

            Assert.AreEqual(2, numbers.Count);
            Assert.AreEqual(1, numbers[0]);
            Assert.AreEqual(2, numbers[1]);
        }

        [TestMethod]
        public void GeneratesFromDreamPhraseCorrectly()
        {
            var numbers = _generator.Convert("ymybiqi");

            Assert.AreEqual("25, 38, 14, 16, 34, 2, 11", numbers.ToString());    //z 26  26  26
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _generator = new Generator();
        }
    }
}
