namespace StaticAbstractMembersOnInterfaces.GenericMath.Money;

public interface IMoney
{
    public static abstract CurrencyCode CurrencyCode { get;}
    public double Value { get;}
}