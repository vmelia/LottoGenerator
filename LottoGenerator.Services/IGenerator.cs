using LottoGenerator.Contracts;

namespace LottoGenerator.Services
{
    public interface IGenerator
    {
        LotteryNumbers Convert(string text);
    }
}
