using ExecuteStoredProceduresInEFCore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ExecuteStoredProceduresInEFCore
{
    public static class SeedManager
    {
        public const int CourseCount = 10;
        public const int StudentCountPerCourse = 100;

        public static async Task SeedData(AppDbContext context)
        {
            if (!context.Courses!.Any())
            {
                List<Course> courses = Enumerable.Range(1, CourseCount).Select(i => new Course
                {
                    Title = $"Course {i}",
                    Students = Enumerable.Range(1, StudentCountPerCourse).Select(j => new Student()
                    {
                        Name = $"Student {10 * i + j}",
                        Mark = j
                    }).ToList()
                }).ToList();

                context.Courses!.AddRange(courses);
                await context.SaveChangesAsync();
            }
        }
    }
}
