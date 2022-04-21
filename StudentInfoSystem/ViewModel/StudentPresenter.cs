using System.Linq;

namespace StudentInfoSystem.ViewModel
{
    public class StudentPresenter : ObservableObject
    {
        public Student Student { get; set; }

        public StudentPresenter()
        {
            Student = StudentData.TestStudents.First();
        }

        public StudentPresenter(string firstName, string facNumber)
        {
            Student = StudentData.TestStudents.FirstOrDefault(s => s.FirstName != null &&
                                                                   s.FirstName.Equals(firstName) &&
                                                                   s.FacultyNumber != null &&
                                                                   s.FacultyNumber.Equals(facNumber)) ??
                      StudentData.TestStudents.First();
        }
    }
}