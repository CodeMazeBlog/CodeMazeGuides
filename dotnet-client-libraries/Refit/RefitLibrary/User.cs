namespace RefitLibrary;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public override string ToString() =>
        string.Join(Environment.NewLine, $"Id: {Id}, Name: {Name}, Email: {Email}");
}
