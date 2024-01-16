namespace HowToUseTheArraySegmentStructInCSharp;

public static class Utilities
{
    public static int GetArraySegmentLength<T>(T[] array)
    {
        var arrayView = new ArraySegment<T>(array);
        return arrayView.Count;
    }

    public static int GetArraySegmentLength<T>(T[] array, int from, int howMany)
    {
        var arraySegment = new ArraySegment<T>(array, from, howMany);
        return arraySegment.Count;
    }

    public static T RetrieveElement<T>(ArraySegment<T> arraySegment, int index)
    {
        return arraySegment[index];
    }

    public static T[] GetOriginalArray<T>(ArraySegment<T> arraySegment)
    {
        return arraySegment.Array;
    }

    public static int CountElementsInSegment<T>(ArraySegment<T> arraySegment)
    {
        return arraySegment.Count;
    }

    public static int GetOffset<T>(ArraySegment<T> arraySegment)
    {
        return arraySegment.Offset;
    }

    public static ArraySegment<T> CreateEmptySegment<T>()
    {
        return ArraySegment<T>.Empty; 
    }

    public static bool CompareArraySegments<T>(ArraySegment<T> arraySegment1, ArraySegment<T> arraySegment2)
    {
        return arraySegment1 == arraySegment2;
    }

    public static ArraySegment<T> GetSegmentSlice<T>(ArraySegment<T> arraySegment, int start, int length = 0)
    {
        return length == 0 ? arraySegment.Slice(start) : arraySegment.Slice(start, length);
    }

    public static void ModifySegmentElement<T>(ArraySegment<T> arraySegment, int index, T newValue)
    {
        arraySegment[index] = newValue;
    }
}
