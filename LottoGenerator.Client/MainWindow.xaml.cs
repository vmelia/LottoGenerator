using LottoGenerator.ViewModel;

namespace LottoGenerator.Client
{
    // ReSharper disable once UnusedMember.Global
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }

        private MainViewModel ViewModel { get; }
    }
}
