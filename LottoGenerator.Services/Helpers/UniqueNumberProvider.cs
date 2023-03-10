using System.Collections.Generic;
using LottoGenerator.Contracts;

namespace LottoGenerator.Services.Helpers
{
    public static class UniqueNumberProvider
    {
        public static int ConvertToUniqueNumber(LotteryNumbers numbers, int lastValue, int value)
        {
            var uniqueValue = GetUniqueValue(numbers, lastValue, value);
            if (uniqueValue == 0)
            {
                //We are back to a previously tried number.
                //This algorithm will increment until a new value is found.
                uniqueValue = GetUniqueValue(numbers, lastValue + value, 1);
            }

            return uniqueValue;
        }

        private static int GetUniqueValue(LotteryNumbers numbers, int lastValue, int increment)
        {
            var triedValues = new List<int>();
            var potentialUniqueValue = RangeChecker.Process(lastValue + increment);
            while (numbers.Contains(potentialUniqueValue))
            {
                triedValues.Add(potentialUniqueValue);
                potentialUniqueValue = RangeChecker.Process(potentialUniqueValue + increment);
                if (triedValues.Contains(potentialUniqueValue))
                {
                    return 0;
                }
            }

            return potentialUniqueValue;
        }
    }
}