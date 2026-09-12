namespace FilteringResultsInsideInclude.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
