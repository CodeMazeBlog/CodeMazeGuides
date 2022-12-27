namespace ActionFuncInCsharp
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public static IEnumerable<Course> DummyeCourses()
        {
            return new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Name = "ASP.NET CORE API",
                    Price = 100
                },
                new Course
                {
                    Id = 2,
                    Name = "C#",
                    Price = 50
                },
                new Course
                {
                    Id = 3,
                    Name = "ASP.NET CORE MVC",
                    Price = 100
                },
                new Course
                {
                    Id = 4,
                    Name = "DOCKER",
                    Price = 75
                },
                new Course
                {
                    Id = 5,
                    Name = "PYTHON",
                    Price = 50
                }
            };
        }
    }
}
