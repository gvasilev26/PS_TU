using StudentInfoSystem.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new StudentPresenter();
            InitializeComponent();
            foreach(var tb in PersonalInformation.Children.OfType<TextBox>())
                tb.IsEnabled = false;
            foreach(var tb in StudentInformation.Children.OfType<TextBox>())
                tb.IsEnabled = false;
        }

        private void ClearFormHandler(object sender, RoutedEventArgs e)
        {
            foreach(var tb in PersonalInformation.Children.OfType<TextBox>())
                tb.Text = "";
            foreach(var tb in StudentInformation.Children.OfType<TextBox>())
                tb.Text = "";
        }

        private void DisableFieldsHandler(object sender, RoutedEventArgs e)
        {
            foreach(var tb in PersonalInformation.Children.OfType<TextBox>())
                tb.IsEnabled = false;
            foreach(var tb in StudentInformation.Children.OfType<TextBox>())
                tb.IsEnabled = false;
        }

        private void EnableFieldsHandler(object sender, RoutedEventArgs e)
        {
            foreach(var tb in PersonalInformation.Children.OfType<TextBox>())
                tb.IsEnabled = true;
            foreach(var tb in StudentInformation.Children.OfType<TextBox>())
                tb.IsEnabled = true;
        }
    }
}