namespace StaticAbstractMembersOnInterfaces.GenericMath.Money;

public class USDollar(double value) : IMoney, INumberRepresentable<USDollar>
{
    public static CurrencyCode CurrencyCode => CurrencyCode.USD;
    public double Value => value;
    public static USDollar Zero => new(0.0);
    
    public static USDollar operator +(USDollar left, USDollar right)
    {
        var sum = left.Value + right.Value;
        return new USDollar(sum);
    }

    public static USDollar operator -(USDollar left, USDollar right)
    {
        var difference = left.Value - right.Value;
        return new USDollar(difference);
    }
}