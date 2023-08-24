namespace GettingStartedASPNETMongoDB.Models
{
    public class SchoolDatabaseSettings
    {
        public string StudentsCollectionName { get; set; }

        public string CoursesCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}