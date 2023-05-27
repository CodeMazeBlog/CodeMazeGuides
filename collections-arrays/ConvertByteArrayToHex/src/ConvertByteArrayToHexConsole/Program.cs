using ConvertByteArrayToHexLibrary;

var source = new byte[] {222, 173, 190, 239, 222, 202, 251, 173};

var result = ConversionHelpers.ToHexWithBitConverter(source);
Console.WriteLine(result);

result = ConversionHelpers.ToHexWithBitConverter(source, true);
Console.WriteLine(result);

result = ConversionHelpers.ToHexWithStringBuilderAppend(source);
Console.WriteLine(result);

result = ConversionHelpers.ToHexWithTryFormatAndStringCreate(source);
Console.WriteLine(result);

result = ConversionHelpers.ToHexWithBitManipulation(source);
Console.WriteLine(result);

result = ConversionHelpers.ToHexWithAlphabetSpanLookup(source);
Console.WriteLine(result);

result = ConversionHelpers.ToHexWithLookup(source);
Console.WriteLine(result);

result = ConversionHelpers.ToHexWithConvert(source);
Console.WriteLine(result);