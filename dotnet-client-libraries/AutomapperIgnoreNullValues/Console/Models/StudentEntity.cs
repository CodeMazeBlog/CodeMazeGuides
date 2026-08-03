namespace AutoMapperIgnoreNullValues;
public class StudentEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<decimal> Grades { get; set; }
    public string Department { get; set; }
    public University University { get; set; }
}