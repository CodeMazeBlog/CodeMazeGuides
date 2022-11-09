using ExecuteStoredProceduresInEFCore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ExecuteStoredProceduresInEFCore
{
    public static class Methods
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


        #region Implemented Find methods
        public static List<Student>? FindStudentsFromSql(AppDbContext context, string searchFor)
        {
            return context?.Students?.FromSql($"FindStudents {searchFor}").ToList();
        }

        public static List<Student>? FindStudentsFromSqlRaw(AppDbContext context, string searchFor)
        {
            return context?.Students?.FromSqlRaw("FindStudents @searchFor", 
                    new SqlParameter("@searchFor", searchFor)).ToList();
        }

        public static List<Student>? FindStudentsFromSqlRawUnsafe(AppDbContext context, string searchFor)
        {
            return context?.Students?.FromSqlRaw($"FindStudents @searchFor = '{searchFor}'").ToList();
        }

        public static List<Student>? FindStudentsFromSqlInterpolated(AppDbContext context, string searchFor)
        {
            return context?.Students?.FromSqlInterpolated($"FindStudents {searchFor}").ToList();
        }

        public static List<Student>? FindStudentsAltFromSqlRaw(AppDbContext context, string searchFor)
        {
            return context?.Students?.FromSqlRaw("FindStudentsAlt @searchFor", 
                new SqlParameter("@searchFor", searchFor)).ToList();
        }

        public static List<Student>? FindStudentsAltFromSqlInterpolated(AppDbContext context, string searchFor)
        {
            return context?.Students?.FromSqlInterpolated($"FindStudentsAlt {searchFor}").ToList();
        }
        #endregion

        #region Implemented Update methods
        public static int UpdateStudentMarkSql(AppDbContext context, int id, int mark)
        {
            return context.Database.ExecuteSql($"UpdateStudentMark @Id={id}, @Mark={mark}");
        }
        public async static Task<int> UpdateStudentMarkSqlAsync(AppDbContext context, int id, int mark)
        {
            return await context.Database.ExecuteSqlAsync($"UpdateStudentMark @Id={id}, @Mark={mark}");
        }

        public static int UpdateStudentMarkSqlRaw(AppDbContext context, int id, int mark)
        {
            return context.Database.ExecuteSqlRaw("dbo.UpdateStudentMark @Id, @Mark", 
                            new SqlParameter("@Id", id),
                            new SqlParameter("@Mark", mark));
        }
        public async static Task<int> UpdateStudentMarkSqlRawAsync(AppDbContext context, int id, int mark)
        {
            return await context.Database.ExecuteSqlRawAsync("dbo.UpdateStudentMark @Id, @Mark",
                            new SqlParameter("@Id", id),
                            new SqlParameter("@Mark", mark));
        }

        public static int UpdateStudentMarkSqlInterpolated(AppDbContext context, int id, int mark)
        {
            return context.Database.ExecuteSqlInterpolated($"UpdateStudentMark @Id={id}, @Mark={mark}");
        }
        public async static Task<int> UpdateStudentMarkSqlInterpolatedAsync(AppDbContext context, int id, int mark)
        {
            return await context.Database.ExecuteSqlInterpolatedAsync($"UpdateStudentMark @Id={id}, @Mark={mark}");
        }
        #endregion
    }
}
