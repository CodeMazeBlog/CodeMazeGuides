using SortingGenericList.Library.DataModels;

namespace SortingGenericList.Library;

public class ShapeCircumferenceComparer : Comparer<Shape>
{
    public override int Compare(Shape? x, Shape? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x is null) return -1;
        if (y is null) return 1;

        var circumferenceCompare = x.Circumference.CompareTo(y.Circumference);

        return circumferenceCompare != 0 ? circumferenceCompare : x.Area.CompareTo(y.Area);
    }
}