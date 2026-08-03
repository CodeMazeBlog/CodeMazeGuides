namespace RetrievePropertyValuebyNameinCSharp;
public class Person
{
    private Guid _id = Guid.NewGuid();

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; } = default;
    public bool IsDeleted { get; set; }
}
