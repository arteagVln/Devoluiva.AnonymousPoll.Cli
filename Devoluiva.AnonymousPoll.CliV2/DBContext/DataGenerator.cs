using Devoluiva.AnonymousPoll.CliV2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Devoluiva.AnonymousPoll.CliV2.DBContext;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new StudentContext(serviceProvider.GetRequiredService<DbContextOptions<StudentContext>>()))
        {
            // Insert students
            if (!context.Students.Any())
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\students.txt");
                string[] studentsList = File.ReadAllLines(path);

                var students = studentsList.Select(x => x.Split(','))
                    .Select(s => new StudentEntity()
                    {
                        Name = s[0],
                        Gender = s[1],
                        Age = int.Parse(s[2]),
                        Education = s[3],
                        AcademicYear = int.Parse(s[4])
                    });

                context.AddRange(students);
                context.SaveChanges();
            }
        }
    }
}
