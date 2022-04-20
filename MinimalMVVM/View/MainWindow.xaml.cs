using System.Windows;
using System.Windows.Controls;
using MinimalMVVM.ViewModel;

namespace MinimalMVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isUpper = true;
        private readonly UpperCasePresenter _upperCasePresenter = new UpperCasePresenter();
        private readonly LowerCasePresenter _lowerCasePresenter = new LowerCasePresenter();
        public MainWindow()
        {
            DataContext = _upperCasePresenter;
            InitializeComponent();
        }

        private void ChangeViewModel(object sender, RoutedEventArgs routedEventArgs)
        {
            _isUpper = !_isUpper;
            DataContext = _isUpper ? (object) _upperCasePresenter : _lowerCasePresenter;
        }
    }
}
