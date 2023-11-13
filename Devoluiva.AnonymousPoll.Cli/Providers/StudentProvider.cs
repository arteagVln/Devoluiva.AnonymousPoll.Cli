using Devoluiva.AnonymousPoll.Library.Interfaces.Providers;
using Devoluiva.AnonymousPoll.Library.Models;
using System.Reflection;
using Devoluiva.AnonymousPoll.Cli.Helpers;

namespace Devoluiva.AnonymousPoll.Cli.Providers;

public class StudentProvider : IStudentProvider
{
    public Student[] GetStudents()
    {
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\students.txt");
        string[] studentsList = File.ReadAllLines(path);

        var students = studentsList.Select(x => x.Split(','))
            .Select(s => new Student()
            {
                Name = s[0],
                Gender = s[1],
                Age = Parsers.ParseInteger(s[2]),
                Education = s[3],
                AcademicYear = Parsers.ParseInteger(s[4])
            })
            .ToArray();

        return students;
    }
}
