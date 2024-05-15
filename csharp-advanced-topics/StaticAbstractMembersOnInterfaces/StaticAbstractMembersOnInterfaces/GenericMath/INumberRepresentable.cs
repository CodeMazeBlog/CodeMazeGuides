using System.Numerics;

namespace StaticAbstractMembersOnInterfaces.GenericMath;

public interface INumberRepresentable<T> :
    IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>
    where T : INumberRepresentable<T>
{
    public static abstract T Zero { get; }
}