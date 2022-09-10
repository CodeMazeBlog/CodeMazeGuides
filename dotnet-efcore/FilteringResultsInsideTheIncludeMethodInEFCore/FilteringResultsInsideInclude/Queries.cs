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

        public static List<Course> NotSupportedMethod(AppDbContext context)
        {
            var badQuery = context.Courses!.Include(c => c.Students!.Any(s => s.Mark > 50)).ToList();
            return badQuery;
        }

        public static List<Course> StandAloneFilter(AppDbContext context)
        {
            var goodQuery = context.Courses!.Include(c => c.Students!.Where(s => s.Id == s.Course!.Id)).ToList();
            return goodQuery;
        }

        public static List<Course> NotStandAloneFilter(AppDbContext context)
        {
            var badQuery = context.Courses!.Include(c => c.Students!.Where(s => s.Id == c.Id)).ToList();
            return badQuery;
        }

        public static List<Course> GoodFilteringOnMultipleInclude(AppDbContext context)
        {
            var goodQuery = context.Courses!
                .Include(c => c.Students!.Where(s => s.Mark > 50))
                .Include(c => c.Students!.Where(s => s.Mark > 50))
                .ToList();

            return goodQuery;
        }

        public static List<Course> BadFilteringOnMultipleInclude(AppDbContext context)
        {
            var badQuery = context.Courses!
                .Include(c => c.Students!.Where(s => s.Mark > 50))
                .Include(c => c.Students!.Where(s => s.Mark <= 50))
                .ToList();

            return badQuery;
        }

        public static (List<Course>, List<Course>) FilteredIncludeWithTrackingQueries1(AppDbContext context)
        {
            var query1 = context.Courses!
                .Include(c => c.Students!.Where(s => s.Mark > 50)).ToList(); 
            var query2 = context.Courses!
                .Include(c => c.Students!.Where(s => s.Mark <= 50)).ToList();

            return (query1, query2);
        }

        public static (List<Course>, List<Course>) FilteredIncludeWithNotTrackingQueries(AppDbContext context)
        {
            var query1 = context.Courses!
                .AsNoTracking()
                .Include(c => c.Students!.Where(s => s.Mark > 50)).ToList();
            var query2 = context.Courses!
                .AsNoTracking()
                .Include(c => c.Students!.Where(s => s.Mark <= 50)).ToList();

            return (query1, query2);
        }

        public static List<Course> FilteredIncludeWithTrackingQueries2(AppDbContext context)
        {
            var courses = context.Courses!.Include(c => c.Students!.Where(s => s.Mark > 50)).ToList(); 
            var students = context.Students!.Where(s => s.Mark <= 50).ToList();

            return courses;
        }

        public static List<Course> FilteringInsideIncludeAndSelectMethod(AppDbContext context)
        {
            var courses = context.Courses!
                .Include(x => x.Students!.Where(x => x.Mark > 50))
                .Select(c => new Course 
                { 
                    Id = c.Id,
                    Title = c.Title,
                    Students = c.Students!.ToList() 
                }).ToList();

            return courses;
        }
        
        public static List<Course> FilteringInsideSelectMethodWithoutInclude(AppDbContext context)
        {
            var courses = context.Courses!
                .Select(c => new Course 
                { 
                    Id = c.Id,
                    Title = c.Title,
                    Students = c.Students!.Where(x => x.Mark > 50).ToList()
                }).ToList();

            return courses;
        }

    }
}
