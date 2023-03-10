namespace LottoGenerator.Contracts
{
    public interface ILottoGeneratorService
    {
        // ReSharper disable once UnusedMemberInSuper.Global
        LotteryNumbers GetLottoNumbers(string text, bool sort);

        string GetLottoNumbersText(string text, bool sort);
    }
}
