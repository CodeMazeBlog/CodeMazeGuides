namespace MultiplePostActionsInController.Models
{
    public class Student
    {
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
