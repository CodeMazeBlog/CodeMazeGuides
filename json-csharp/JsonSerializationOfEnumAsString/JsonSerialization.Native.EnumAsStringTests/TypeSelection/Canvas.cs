namespace JsonSerialization.Native.EnumAsStringTests.TypeSelection;

public class Canvas
{
    public static Canvas Poster 
        => new() { Name = "Poster", BackColor = Color.LightGray, Pen = new("Simple", Color.Red) };

    public string? Name { get; set; }

    public Color BackColor { get; set; }

    public Medium Medium { get; set; }

    public Pen? Pen { get; set; }
}

public record struct Pen(string Name, Color Color);

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Color
{
    White, LightGray, DarkGray, Red
}

public enum Medium
{
    Water, Oil
}
