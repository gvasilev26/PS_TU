using System.Collections.Generic;
using System.Collections.ObjectModel;
using StudentInfoSystem;

namespace StudentInfoSystem;

public static class StudentData
{
    public static ObservableCollection<Student> TestStudents { get; } = new()
    {
        new Student("Georgi", "Rumenov", "Vasilev", "FKST", "KSI", "Middle", "Assigned", "121219040", 6, 2, 30),
        new Student("Test", "Test", "Test", "FKST", "KSI", "Middle", "Assigned", "123", 6, 2, 30)
    };
}   