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
            InitializeComponent();
        }

        private void ClearFormHandler(object sender, RoutedEventArgs e)
        {
            foreach(var tb in PersonalInformation.Children.OfType<TextBox>())
                tb.Text = "";
            foreach(var tb in StudentInformation.Children.OfType<TextBox>())
                tb.Text = "";
        }

        private void FillSampleDataHandler(object sender, RoutedEventArgs e)
        {
            var student = StudentData.TestStudents.First();
            FirstNameField.Text = student.FirstName;
            MiddleNameField.Text = student.MiddleName;
            LastNameField.Text = student.LastName;
            FacultyField.Text = student.Faculty;
            SpecialityField.Text = student.Speciality;
            OkcField.Text = student.EducationDegree;
            StatusField.Text = student.Status;
            FacultyNumberField.Text = student.FacultyNumber;
            CourseField.Text = student.Course.ToString();
            FlowField.Text = student.Flow.ToString();
            GroupField.Text = student.Group.ToString();
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