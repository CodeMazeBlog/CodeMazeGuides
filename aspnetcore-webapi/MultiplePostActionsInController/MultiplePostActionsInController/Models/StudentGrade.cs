namespace MultiplePostActionsInController.Models
{
    public class StudentGrade
    {
        public int StudentId { get; set; }
        public double Grade { get; set; }

        public StudentGrade(int studentId, double grade)
        {
            StudentId = studentId;
            Grade = grade;
        }
    }
}
