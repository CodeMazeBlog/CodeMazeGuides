namespace AutomapperVsMapster.CollectionMapping;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
    public string Email { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}