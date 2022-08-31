using FilteringResultsInsideInclude.Models;
using Microsoft.EntityFrameworkCore;

namespace FilteringResultsInsideInclude
{
    public class Queries
    {
        public const int CourseCount = 10;
        public const int StudentCountPerCourse = 100;
        
        public static async Task SeedData(AppDbContext context)
        {
            if (!context.Courses.Any())
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

                context.Courses.AddRange(courses);
                await context.SaveChangesAsync();
            }
        }

        public static List<Course> NotSupportedMethod(AppDbContext context)
        {
            return context.Courses.Include(c => c.Students.Any(s => s.Mark > 50)).ToList();
        }

        public static List<Course> StandAloneFilter(AppDbContext context)
        {
            return context.Courses.Include(c => c.Students.Where(s => s.Id == s.Course.Id)).ToList();
        }

        public static List<Course> NotStandAloneFilter(AppDbContext context)
        {
            return context.Courses.Include(c => c.Students.Where(s => s.Id == c.Id)).ToList();
        }

        public static (List<Course>, List<Course>) RightFilteringOnMultipleInclude(AppDbContext context)
        {
            var rightQuery1 = context.Courses
                .Include(c => c.Students.Where(s => s.Mark > 50))
                .Include(c => c.Students.Where(s => s.Mark > 50))
                .ToList();

            var rightQuery2 = context.Courses
                .Include(c => c.Students.Where(s => s.Mark > 50))
                .Include(c => c.Students)
                .ToList();

            return (rightQuery1, rightQuery2);
        }

        public static List<Course> BadFilteringOnMultipleInclude(AppDbContext context)
        {
            var badQuery = context.Courses
                .Include(c => c.Students.Where(s => s.Mark > 50))
                .Include(c => c.Students.Where(s => s.Mark <= 50))
                .ToList();

            return badQuery;
        }

        public static (List<Course>, List<Course>) FilteredIncludeWithTrackingQueries1(AppDbContext context)
        {
            var query1 = context.Courses.Include(c => c.Students.Where(s => s.Mark > 50)).ToList(); 
            var query2 = context.Courses.Include(c => c.Students.Where(s => s.Mark <= 50)).ToList();

            return (query1, query2);
        }

        public static List<Course> FilteredIncludeWithTrackingQueries2(AppDbContext context)
        {
            var courses = context.Courses.Include(c => c.Students.Where(s => s.Mark > 50)).ToList(); 
            var students = context.Students.Where(s => s.Mark <= 50).ToList();

            return courses;
        }

        public static List<List<Student>> FilteringInsideIncludeAndSelectMethod(AppDbContext context)
        {
            var students = context.Courses
                .Include(c => c.Students.Where(s => s.Mark > 50))
                .Select(c => c.Students.ToList())
                .ToList();

            return students;
        }
        
        public static List<List<Student>> FilteringInsideSelectMethodWithoutInclude(AppDbContext context)
        {
            var students = context.Courses
                .Select(c => c.Students.Where(x => x.Mark > 50).ToList())
                .ToList();

            return students;
        }
    }
}
