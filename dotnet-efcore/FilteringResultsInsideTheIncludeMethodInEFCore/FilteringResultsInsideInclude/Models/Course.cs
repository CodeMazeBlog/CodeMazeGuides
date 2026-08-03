namespace FilteringResultsInsideInclude.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}
