namespace ConvertHexStringToByteArrayUnitTests;

public class LookupTableTests
{
    [Fact]
    public void WhenComputingLookupTables_ReceiveExpectedLowBitResult()
    {
        var (lowBits, _) = LookupTables.CreateLookups();

        Assert.True(LookupTables.FromHexLowBitsLookup.SequenceEqual(lowBits));
    }

    [Fact]
    public void WhenComputingLookupTables_ReceiveExpectedHighBitResult()
    {
        var (_, highBits) = LookupTables.CreateLookups();

        Assert.True(LookupTables.FromHexHighBitsLookup.SequenceEqual(highBits));
    }
}