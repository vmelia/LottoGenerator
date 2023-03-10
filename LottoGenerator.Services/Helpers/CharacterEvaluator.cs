namespace LottoGenerator.Services.Helpers
{
    public static class CharacterEvaluator
    {
        public static int Convert(char character)
        {
            return char.ToLower(character) - 'a' + 1;
        }
    }
}
