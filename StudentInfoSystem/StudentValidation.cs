using System;
using System.Linq;
using UserLogin;

namespace StudentInfoSystem;

public class StudentValidation
{
    public Student GetStudentDataByUser(User user)
    {
        foreach (var student in StudentData.TestStudents.Where(student => student.FacultyNumber == user.FacultyNumber))
        {
            return student;
        }

        throw new Exception("Student not found");
    }
}