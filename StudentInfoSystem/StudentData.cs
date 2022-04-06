using System.Collections.Generic;

namespace StudentInfoSystem;

public static class StudentData
{
    public static List<Student> TestStudents { get; } = new()
    {
        new Student("Miroslav", "Mladenov", "Mihaylov", "FKST", "KSI", "Middle", "Assigned", "121219041", 6, 2, 30)
    };
}