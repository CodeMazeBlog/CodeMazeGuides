namespace AutoMapperIgnoreNullValues;
public class StudentItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AgeInfo { get; set; }
    public List<decimal> Grades { get; set; }
    public string Department { get; set; }
    public University University { get; set; }
    public bool IsGraduated { get; set; }
}
