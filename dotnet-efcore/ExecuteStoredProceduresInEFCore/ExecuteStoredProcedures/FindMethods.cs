using ExecuteStoredProceduresInEFCore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ExecuteStoredProceduresInEFCore
{
    public static class FindMethods
    {
        public static List<Student>? FindStudentsFromSql(AppDbContext context, string searchFor)
        {
            return context?.Students?.FromSql($"FindStudents {searchFor}").ToList();
        }

        public static List<Student>? FindStudentsFromSqlDynamic(AppDbContext context, string methodName, string searchFor)
        {
            return context?.Students?.FromSql($"{methodName} {searchFor}").ToList();
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

        public static List<Student>? FindStudentsDynamic(AppDbContext context, string searchFor, bool altMethod)
        {
            return context?.Students?.FromSqlRaw("FindStudentsAlt @searchFor",
                new SqlParameter("@searchFor", searchFor)).ToList();
        }

        public static List<Student>? FindStudentsAltFromSqlInterpolated(AppDbContext context, string searchFor)
        {
            return context?.Students?.FromSqlInterpolated($"FindStudentsAlt {searchFor}").ToList();
        }

        public static List<Student>? FindStudentsFromSqlAndLinq(AppDbContext context, string searchFor)
        {
            return context?.Students?
                .FromSql($"SELECT * FROM Students")
                .Where(m => m.Name != null && m.Name.IndexOf(searchFor) > -1)
                .OrderBy(m => m.Mark)
                .ToList();
        }

        public static int? FindStudentsFromSqlAndUpdateMarks(AppDbContext context, string searchFor)
        {
            var students = context?.Students?
                .FromSql($"FindStudents {searchFor}").ToList();

            if (students != null)
                foreach (var student in students)
                    student.Mark += 1;

            return context?.SaveChanges();
        }
    }
}
