namespace EnumerateAnEnumInCSharp;

internal enum OrderStatus
{
    Cancelled = -1,
    Pending = 0,
    Paid = 1,
    Shipped = 2,
    Dispatched = 2 // the old name, kept so existing code still compiles
}
