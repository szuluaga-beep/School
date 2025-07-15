using Microsoft.EntityFrameworkCore;
using School.Data;

namespace School.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.Course.Any() || context.Student.Any())
                {
                    return; // DB has been seeded
                }

                // Seed Courses

                var courses = new Course[]
                {
                           new Course { Name = "Mathematics", CourseCode = "MATH101", Credits = 3 },
                           new Course { Name = "Physics", CourseCode = "PHYS101", Credits = 4 },
                           new Course { Name = "Chemistry", CourseCode = "CHEM101", Credits = 3 },
                           new Course { Name = "Biology", CourseCode = "BIOL101", Credits = 3 }
                };
                foreach (var course in courses)
                {
                    context.Course.Add(course);
                }
                context.SaveChanges();

                // Seed Students

                var students = new Student[]
                {
                           new Student { FullName = "Steven Zuluaga", Email = "steven@yopmail.com", Document = "123456789" },
                           new Student { FullName = "Maria Gonzalez", Email = "maria@yopmail.com", Document = "987654321" },
                           new Student { FullName = "John Doe", Email = "john@yopmail.com", Document = "456789123" },
                           new Student { FullName = "Jane Smith", Email = "jane@yopmail.com", Document = "789123456" },
                           new Student { FullName = "Carlos Perez", Email = "carlos@yopmail.com", Document = "321654987" }
                };
                foreach (var student in students)
                {
                    context.Student.Add(student);
                }
                context.SaveChanges();

                // Seed Course-Student relationships
                var courseStudents = new CourseStudent[]
{
                   new CourseStudent { CourseId = courses.Single(c => c.Name == "Mathematics").Id, StudentId = students.Single(s => s.FullName == "Steven Zuluaga").Id },
                   new CourseStudent { CourseId = courses.Single(c => c.Name == "Physics").Id, StudentId = students.Single(s => s.FullName == "Steven Zuluaga").Id },
                   new CourseStudent { CourseId = courses.Single(c => c.Name == "Physics").Id, StudentId = students.Single(s => s.FullName == "Maria Gonzalez").Id },
                   new CourseStudent { CourseId = courses.Single(c => c.Name == "Chemistry").Id, StudentId = students.Single(s => s.FullName == "John Doe").Id },
                   new CourseStudent { CourseId = courses.Single(c => c.Name == "Biology").Id, StudentId = students.Single(s => s.FullName == "Jane Smith").Id },
                   new CourseStudent { CourseId = courses.Single(c => c.Name == "Mathematics").Id, StudentId = students.Single(s => s.FullName == "Carlos Perez").Id }
};
                foreach (var courseStudent in courseStudents)
                {
                    context.Add(courseStudent);
                }
                context.SaveChanges();
            }
        }
    }
}