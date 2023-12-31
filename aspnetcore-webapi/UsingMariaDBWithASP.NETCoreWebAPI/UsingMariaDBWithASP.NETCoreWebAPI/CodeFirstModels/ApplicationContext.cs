using Microsoft.EntityFrameworkCore;

namespace UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options): DbContext(options)
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Students
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "John",
                    SecondName = "Doe",
                    Address = "123 Main St",
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Jane",
                    SecondName = "Doe",
                    Address = "456 Oak St",
                }
            );

            // Seed data for Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Biology", CreditUnit = 4 },
                new Course { Id = 2, Title = "Mathematics", CreditUnit = 3 },
                new Course { Id = 3, Title = "Physics", CreditUnit = 3 }
            );

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    r => r.HasOne<Course>().WithMany().OnDelete(DeleteBehavior.Cascade).HasForeignKey("CourseId"),
                    l => l.HasOne<Student>().WithMany().OnDelete(DeleteBehavior.Cascade).HasForeignKey("StudentId"),
                    je =>
                    {
                        je.HasKey("StudentId", "CourseId");
                        je.HasData(
                            new { StudentId = 1, CourseId = 1 },
                            new { StudentId = 1, CourseId = 2 },
                            new { StudentId = 1, CourseId = 3 },
                            new { StudentId = 2, CourseId = 1 },
                            new { StudentId = 2, CourseId = 2 },
                            new { StudentId = 2, CourseId = 3 });
                    });
        }
    }
}