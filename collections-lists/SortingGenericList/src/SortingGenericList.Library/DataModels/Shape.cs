namespace SortingGenericList.Library.DataModels;

public abstract class Shape : IComparable<Shape>, IComparable, IEquatable<Shape>
{
    private const double Tolerance = 1E-12;

    public abstract double Area { get; }

    public abstract double Circumference { get; }

    public static bool operator <(Shape? left, Shape? right) => Comparer<Shape>.Default.Compare(left, right) < 0;

    public static bool operator >(Shape? left, Shape? right) => Comparer<Shape>.Default.Compare(left, right) > 0;

    public static bool operator <=(Shape? left, Shape? right) => Comparer<Shape>.Default.Compare(left, right) <= 0;

    public static bool operator >=(Shape? left, Shape? right) => Comparer<Shape>.Default.Compare(left, right) >= 0;

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;

        return obj.GetType() == GetType() && Equals((Shape) obj);
    }

    public override int GetHashCode() => HashCode.Combine(Area, Circumference);

    public static bool operator ==(Shape? left, Shape? right) => Equals(left, right);

    public static bool operator !=(Shape? left, Shape? right) => !Equals(left, right);

    public int CompareTo(object? obj)
    {
        if (obj is null) return 1;
        if (ReferenceEquals(this, obj)) return 0;

        return obj is Shape other
            ? CompareTo(other)
            : throw new ArgumentException($"Object must be of type {nameof(Shape)}");
    }

    public int CompareTo(Shape? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;

        var areaComparison = Area.CompareTo(other.Area);

        return areaComparison != 0 ? areaComparison : Circumference.CompareTo(other.Circumference);
    }

    public bool Equals(Shape? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Math.Abs(Area - other.Area) < Tolerance && Math.Abs(Circumference - other.Circumference) < Tolerance;
    }
}