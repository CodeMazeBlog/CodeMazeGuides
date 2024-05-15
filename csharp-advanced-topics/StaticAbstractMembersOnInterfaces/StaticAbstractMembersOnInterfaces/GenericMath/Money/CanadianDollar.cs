namespace StaticAbstractMembersOnInterfaces.GenericMath.Money;

public class CanadianDollar(double value) : IMoney, INumberRepresentable<CanadianDollar>
{
    public static CurrencyCode CurrencyCode => CurrencyCode.CAD;
    public static CanadianDollar Zero => new(0.0);
    public double Value => value;

    public static CanadianDollar operator +(CanadianDollar left, CanadianDollar right)
    {
        var sum = left.Value + right.Value;
        return new CanadianDollar(sum);
    }

    public static CanadianDollar operator -(CanadianDollar left, CanadianDollar right)
    {
        var difference = left.Value - right.Value;
        return new CanadianDollar(difference);
    }
}