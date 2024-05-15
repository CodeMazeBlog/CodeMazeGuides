namespace StaticAbstractMembersOnInterfaces.GenericMath;

public static class GenericCalculator
{
    public static T Add<T>(T left, T right) where T : INumberRepresentable<T>
    {
        return left + right;
    }

    public static T Subtract<T>(T left, T right) where T : INumberRepresentable<T>
    {
        return left - right;
    }
}