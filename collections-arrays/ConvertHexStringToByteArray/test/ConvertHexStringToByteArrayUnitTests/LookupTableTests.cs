namespace ConvertHexStringToByteArrayUnitTests;

public class LookupTableTests
{
    [Fact]
    public void WhenComputingLookupTables_ReceiveExpectedLowBitResult()
    {
        var (lowBits, _) = LookupTables.CreateLookups();

        Assert.Equal(lowBits.Length, LookupTables.FromHexLowBitsLookup.Length);
        Assert.Equal(lowBits, LookupTables.FromHexLowBitsLookup.ToArray());
    }

    [Fact]
    public void WhenComputingLookupTables_ReceiveExpectedHighBitResult()
    {
        var (_, highBits) = LookupTables.CreateLookups();

        Assert.Equal(highBits.Length, LookupTables.FromHexHighBitsLookup.Length);
        Assert.Equal(highBits, LookupTables.FromHexHighBitsLookup.ToArray());
    }
}