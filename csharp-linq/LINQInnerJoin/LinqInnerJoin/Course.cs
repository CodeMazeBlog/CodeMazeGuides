namespace LinqInnerJoin
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public static IEnumerable<Course> GetDummyCourses()
        {
            int id = 1;
            List<Course> courses = new();

            List<string> programmingLanguages = new()
            {
                "CSHARP",
                "PYTHON",
                "JAVA",
                "RUBY",
                "GO"
            };

            List<string> databases = new()
            {
                "MSSQL",
                "POSTGRES",
                "MONGODB",
                "MYSQL"
            };

            List<string> devops = new()
            {
                "DOCKER",
                "JENKINS",
                "GIT",
                "KUBERNETES"
            };

            courses.AddRange(from pr in programmingLanguages
                             select new Course
                             {
                                 Id = id++,
                                 CategoryId = 1,
                                 Name = pr
                             });


            courses.AddRange(from db in databases
                             select new Course
                             {
                                 Id = id++,
                                 CategoryId = 2,
                                 Name = db
                             });


            courses.AddRange(from dv in devops
                             select new Course
                             {
                                 Id = id++,
                                 CategoryId = 3,
                                 Name = dv
                             });

            return courses;
        }
    }
}
