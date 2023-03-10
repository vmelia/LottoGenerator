using System.ComponentModel;
using LottoGenerator.Contracts;
using LottoGenerator.Services;

namespace LottoGenerator.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ILottoGeneratorService _lottoGeneratorService;
        private string _input;
        private string _output;
        private bool _sort;

        public MainViewModel()
        {
            _lottoGeneratorService = new LottoGeneratorService();
            Input = string.Empty;
            Sort = true;
        }

        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged("Input");
                Convert();
            }
        }

        public string Output
        {
            get => _output;
            set
            {
                _output = value;
                OnPropertyChanged("Output");
            }
        }
        public bool Sort
        {
            get => _sort;
            set
            {
                _sort = value;
                OnPropertyChanged("Sort");
                Convert();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Convert()
        {
            //var numbers = _lottoGeneratorService.GetLottoNumbers(Input, Sort);
            //Output = numbers.ToString();
            Output = _lottoGeneratorService.GetLottoNumbersText(Input, Sort);
        }
    }
}
