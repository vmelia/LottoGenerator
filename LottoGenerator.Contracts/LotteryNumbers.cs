using System;
using System.Collections.Generic;
using System.Text;

namespace LottoGenerator.Contracts
{
    [Serializable]
    public class LotteryNumbers
    {
        private readonly List<int> _numbers;

        public LotteryNumbers()
        {
            _numbers = new List<int>();
        }

        public int Count => _numbers.Count;

        public void Add(int value)
        {
            _numbers.Add(value);
        }

        public int this[int index] => _numbers[index];

        public bool Contains(int value)
        {
            return _numbers.Contains(value);
        }

        public void Sort()
        {
            _numbers.Sort();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var number in _numbers)
            {
                if (result.Length > 0)
                    result.Append(", ");
                result.Append(number);
            }

            return result.ToString();
        }
    }
}
