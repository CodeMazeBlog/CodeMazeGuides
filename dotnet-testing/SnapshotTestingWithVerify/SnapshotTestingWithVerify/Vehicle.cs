namespace SnapshotTestingWithVerify;

public class Vehicle
{
    public Guid Id { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public string? Color { get; set; }
    public Address? Location { get; set; }
    public List<string>? Features { get; set; }
}