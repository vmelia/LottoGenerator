using LottoGenerator.Contracts;

namespace LottoGenerator.Services
{
    public class LottoGeneratorService : ILottoGeneratorService
    {
        public LotteryNumbers GetLottoNumbers(string text, bool sort)
        {
            IGenerator generator = new Generator();
            var numbers = generator.Convert(text);
            if (sort)
                numbers.Sort();

            return numbers;
        }

        public string GetLottoNumbersText(string text, bool sort)
        {
            var numbers = GetLottoNumbers(text, sort);

            return numbers.ToString();
        }
    }
}
