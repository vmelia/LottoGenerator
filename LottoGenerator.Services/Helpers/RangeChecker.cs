namespace LottoGenerator.Services.Helpers
{
    public static class RangeChecker
    {
        static RangeChecker()
        {
            MaximumValue = 49;
        }
        public static int MaximumValue { get; set; }

        public static int Process(int value)
        {
            var convertedValue = value;
            while (convertedValue > MaximumValue)
                convertedValue -= MaximumValue;

            return convertedValue;
        }
    }
}
