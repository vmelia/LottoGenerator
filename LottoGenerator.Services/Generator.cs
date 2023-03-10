using System.Linq;
using LottoGenerator.Contracts;
using LottoGenerator.Services.Helpers;

namespace LottoGenerator.Services
{
    public class Generator : IGenerator
    {
        private LotteryNumbers _numbers;
        private int _currentValue;

        public LotteryNumbers Convert(string text)
        {
            _currentValue = 0;
            _numbers = new LotteryNumbers();

            if (string.IsNullOrEmpty(text))
                return _numbers;

            foreach (var character in text.Where(char.IsLetter))
            {
                GetNextUniqueValueInRange(character);
            }

            return _numbers;
        }

        private void GetNextUniqueValueInRange(char character)
        {
            var value = CharacterEvaluator.Convert(character);
            _currentValue = UniqueNumberProvider.ConvertToUniqueNumber(_numbers, _currentValue, value);

            _numbers.Add(_currentValue);
        }
    }
}
