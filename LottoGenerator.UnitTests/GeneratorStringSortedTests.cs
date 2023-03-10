using LottoGenerator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoGenerator.UnitTests
{
    [TestClass]
    public class GeneratorStringSortedTests
    {
        private static Generator _generator;

        [TestMethod]
        public void NullStringGeneratesNoNumbers()
        {
            var numbers = _generator.Convert(null);
            numbers.Sort();

            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void EmptyStringGeneratesNoNumbers()
        {
            var numbers = _generator.Convert(string.Empty);
            numbers.Sort();

            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void OneAGeneratesOne()
        {
            var numbers = _generator.Convert("a");
            numbers.Sort();

            Assert.AreEqual(1, numbers.Count);
            Assert.AreEqual(1, numbers[0]);
        }

        [TestMethod]
        public void AandAGenerateCorrectly()
        {
            var numbers = _generator.Convert("aa");
            numbers.Sort();

            Assert.AreEqual(2, numbers.Count);
            Assert.AreEqual(1, numbers[0]);
            Assert.AreEqual(2, numbers[1]);
        }

        [TestMethod]
        public void ZandWGenerateCorrectly()
        {
            var numbers = _generator.Convert("zw");
            numbers.Sort();

            Assert.AreEqual(26, numbers[0]);
            Assert.AreEqual(49, numbers[1]);
        }

        [TestMethod]
        public void ZandXGenerateCorrectly()
        {
            var numbers = _generator.Convert("zx");
            numbers.Sort();

            Assert.AreEqual(1, numbers[0]);
            Assert.AreEqual(26, numbers[1]);
        }

        [TestMethod]
        public void DuplicatesHandleCorrectly()
        {
            var numbers = _generator.Convert("zwz");
            numbers.Sort();

            Assert.AreEqual(3, numbers[0]);     //49 + 26 = 75 => 26. This is used so add increment (26) = 52 => 3.
            Assert.AreEqual(26, numbers[1]);    //'z'.
            Assert.AreEqual(49, numbers[2]);    //'z' + 'w' = 26 + 23 = 49.
        }

        [TestMethod]
        public void GeneratesFromRibisiCorrectly()
        {
            var numbers = _generator.Convert("ribisi");
            numbers.Sort();

            Assert.AreEqual(6, numbers.Count);
        }

        [TestMethod]
        public void GeneratesFromGhmommCorrectly()
        {
            var numbers = _generator.Convert("ghmomm");
            numbers.Sort();

            Assert.AreEqual(07, numbers[0]);    //g
            Assert.AreEqual(15, numbers[1]);    //h 
            Assert.AreEqual(20, numbers[2]);    //m
            Assert.AreEqual(28, numbers[3]);    //m
            Assert.AreEqual(33, numbers[4]);    //m
            Assert.AreEqual(43, numbers[5]);    //o
        }

        [TestMethod]
        public void GeneratesFromZeroCatCorrectly()
        {
            var numbers = _generator.Convert("zerocat");
            numbers.Sort();

            Assert.AreEqual(15, numbers[0]);    //o 15  64  15
            Assert.AreEqual(18, numbers[1]);    //c 3   18  18
            Assert.AreEqual(19, numbers[2]);    //a 1   19  19
            Assert.AreEqual(26, numbers[3]);    //z 26  26  26
            Assert.AreEqual(31, numbers[4]);    //e 5   31  31
            Assert.AreEqual(39, numbers[5]);    //t 20  39  39
            Assert.AreEqual(49, numbers[6]);    //r 18  49  49
        }

        [TestMethod]
        public void GeneratesFromGeorgiaCorrectly()
        {
            var numbers = _generator.Convert("georgia");
            numbers.Sort();

            Assert.AreEqual(03, numbers[0]);    //g
            Assert.AreEqual(07, numbers[1]);    //g
            Assert.AreEqual(12, numbers[2]);    //e 
            Assert.AreEqual(21, numbers[3]);    //i
            Assert.AreEqual(22, numbers[4]);    //a
            Assert.AreEqual(27, numbers[5]);    //o
            Assert.AreEqual(45, numbers[6]);    //r
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _generator = new Generator();
        }
    }
}
