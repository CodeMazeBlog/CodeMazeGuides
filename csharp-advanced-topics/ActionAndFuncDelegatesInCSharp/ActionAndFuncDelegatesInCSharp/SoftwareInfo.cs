public class SoftwareInfo
{
    public string Name { get; }
    public bool IsDevelopmentSoftware { get; }

    public SoftwareInfo(string name, bool isDevelopmentSoftware)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        IsDevelopmentSoftware = isDevelopmentSoftware;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Development Tool: {(this.IsDevelopmentSoftware ? "Yes" : "No")}";
    }
}