namespace ValueObjects.ValueObjects;

public sealed record Route(IReadOnlyList<Station> Stops)
{
    public bool Equals(Route? other) =>
        other is not null && Stops.SequenceEqual(other.Stops);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var stop in Stops)
            hash.Add(stop);

        return hash.ToHashCode();
    }
}
