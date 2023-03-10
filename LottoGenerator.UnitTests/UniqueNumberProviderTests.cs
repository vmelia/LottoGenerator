using LottoGenerator.Contracts;
using LottoGenerator.Services.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoGenerator.UnitTests
{
    [TestClass]
    public class UniqueNumberProviderTests
    {
        private LotteryNumbers _numbers;

        [TestMethod]
        public void EmptyListAlwaysConvertsToTheSameNumber()
        {
            Assert.AreEqual(7, UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 0, 7));
        }

        [TestMethod]
        public void OneMatchConvertsOk()
        {
            _numbers.Add(7);

            Assert.AreEqual(14, UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 0, 7));
        }
        
        [TestMethod]
        public void TwoMatchesConvertOk()
        {
            _numbers.Add(7); 
            _numbers.Add(14);

            Assert.AreEqual(21, UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 0, 7));
        }

        [TestMethod]
        public void OverlapConvertsOk()
        {
            _numbers.Add(25);

            Assert.AreEqual(1, UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 0, 25));
        }

        [TestMethod]
        public void ValueTooHighConvertsOk()
        {
            Assert.AreEqual(1, UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 0, 50));
        }

        [TestMethod]
        public void FiveGsConvertTo8()
        {
            _numbers.Add(7);
            _numbers.Add(14);
            _numbers.Add(21);
            _numbers.Add(28);
            _numbers.Add(35);
            _numbers.Add(42);
            _numbers.Add(49);

            Assert.AreEqual(8, UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 0, 7));
        }

        [TestMethod]
        public void CanConvertEntireRange1()
        {
            for (var index = 1; index <= 48; index++)
                _numbers.Add(index);

            Assert.AreEqual(49, UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 0, 1));
        }

        [TestMethod]
        public void CanConvertEntireRange2()
        {
            for (var index = 1; index <= 48; index++)
                _numbers.Add(index);

            Assert.AreEqual(49, UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 0, 2));
        }

        [TestMethod]
        public void GeorgiaConvertsOk()
        {
            _numbers.Add(UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 00, 07));  //g
            _numbers.Add(UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 07, 05));  //e
            _numbers.Add(UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 12, 15));  //o
            _numbers.Add(UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 27, 18));  //r
            _numbers.Add(UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 45, 07));  //g
            _numbers.Add(UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 03, 09));  //i
            _numbers.Add(UniqueNumberProvider.ConvertToUniqueNumber(_numbers, 21, 01));  //a

            Assert.AreEqual(07, _numbers[0]);    //g
            Assert.AreEqual(12, _numbers[1]);    //e 
            Assert.AreEqual(27, _numbers[2]);    //o
            Assert.AreEqual(45, _numbers[3]);    //r
            Assert.AreEqual(03, _numbers[4]);    //g
            Assert.AreEqual(21, _numbers[5]);    //i
            Assert.AreEqual(22, _numbers[6]);    //a
        }
        
        [TestInitialize]
        public void TestInitialize()
        {
            _numbers = new LotteryNumbers();
        }
    }
}
