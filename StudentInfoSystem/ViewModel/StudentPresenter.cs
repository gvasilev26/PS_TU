using System.Linq;
using System.Windows.Input;

namespace StudentInfoSystem.ViewModel
{
    public class StudentPresenter : ObservableObject
    {
        private Student _student;
        public Student Student { get { return _student; }
            set
            {
                _student = value;
                RaisePropertyChangedEvent("Student");
            } }

        public string LoginFirstName { get; set; } = "";
        public string LoginFacNum { get; set; } = "";
        

        public StudentPresenter()
        {
            Student = StudentData.TestStudents.First();
        }


        public ICommand LoginCommand
        {
            get { return new DelegateCommand(Login); }
        }

        public void Login()
        {
            Student = StudentData.TestStudents.FirstOrDefault(s => s.FirstName != null &&
                                                                   s.FirstName.Equals(LoginFirstName) &&
                                                                   s.FacultyNumber != null &&
                                                                   s.FacultyNumber.Equals(LoginFacNum)) ??
                      StudentData.TestStudents.First();
        }
    }
}