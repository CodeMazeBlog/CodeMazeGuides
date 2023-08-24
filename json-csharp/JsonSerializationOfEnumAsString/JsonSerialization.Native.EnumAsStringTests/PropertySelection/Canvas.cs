namespace JsonSerialization.Native.EnumAsStringTests.PropertySelection;

public class Canvas
{
    public static Canvas Poster 
        => new() { Name = "Poster", BackColor = Color.LightGray, Pen = new("Simple", Color.Red) };

    public string? Name { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Color BackColor { get; set; }

    public Medium Medium { get; set; }

    public Pen? Pen { get; set; }
}

public record struct Pen(string Name, Color Color);

public enum Color
{
    White, LightGray, DarkGray, Red
}

public enum Medium
{
    Water, Oil
}