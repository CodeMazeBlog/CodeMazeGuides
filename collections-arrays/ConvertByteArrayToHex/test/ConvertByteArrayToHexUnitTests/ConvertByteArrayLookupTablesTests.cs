using ConvertByteArrayHexLibrary;

namespace ConvertByteArrayToHexUnitTests;

public class ConvertByteArrayLookupTablesTests
{
    [Fact]
    public void WhenComputingLittleEndianUpperLookupTable_ComputeCorrectTable()
    {
        var table = LookupTables.CreateLookup(false, true);

        Assert.Equal(LookupTables.HexLookupUpperLittleEndian, table);
    }

    [Fact]
    public void WhenComputingLittleEndianLowerLookupTable_ComputeCorrectTable()
    {
        var table = LookupTables.CreateLookup(true, true);

        Assert.Equal(LookupTables.HexLookupLowerLittleEndian, table);
    }

    [Fact]
    public void WhenComputingBigEndianUpperLookupTable_ComputeCorrectTable()
    {
        var table = LookupTables.CreateLookup(false, false);

        Assert.Equal(LookupTables.HexLookupUpperBigEndian, table);
    }

    [Fact]
    public void WhenComputingBigEndianLowerLookupTable_ComputeCorrectTable()
    {
        var table = LookupTables.CreateLookup(true, false);

        Assert.Equal(LookupTables.HexLookupLowerBigEndian, table);
    }

    [Fact]
    public void WhenComputingLittleEndianAndBigEndian_TablesDiffer()
    {
        var leTable = LookupTables.CreateLookup(false, true);
        var beTable = LookupTables.CreateLookup(false, false);

        Assert.NotEqual(leTable, beTable);
    }
}