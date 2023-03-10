using LottoGenerator.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoGenerator.UnitTests
{
    [TestClass]
    public class LotteryNumbersTests
    {
        [TestMethod]
        public void NewNumbersIsEmpty()
        {
            var numbers = new LotteryNumbers();

            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void AddedNumbersPersist()
        {
            var numbers = new LotteryNumbers();
            numbers.Add(26);
            numbers.Add(1);

            Assert.AreEqual(2, numbers.Count);
            Assert.AreEqual(26, numbers[0]);
            Assert.AreEqual(1, numbers[1]);
        }

        [TestMethod]
        public void SingleValueToStringWorks()
        {
            var numbers = new LotteryNumbers();
            numbers.Add(26);

            Assert.AreEqual("26", numbers.ToString());
        }
        
        [TestMethod]
        public void MultipleValuesToStringWorks()
        {
            var numbers = new LotteryNumbers();
            numbers.Add(49);
            numbers.Add(1); 
            numbers.Add(26);

            Assert.AreEqual("49, 1, 26", numbers.ToString());
        }
    }
}
