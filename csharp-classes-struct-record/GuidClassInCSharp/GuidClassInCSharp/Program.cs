using static GuidClassInCSharp.GuidClassInCSharpMethods;

Console.WriteLine("Random Guid: "+ CreateRandomGuid());
Console.WriteLine("Specific Guid: " + CreateSpecificGuid("2B5EEF8C-A4CB-4F13-B90A-7AB26E57A64C"));
Console.WriteLine("Empty Guid: " + CreateEmptyGuid());
Console.WriteLine("Guid To Bytes: " + GuidToByteString(new Guid("e2f24f93-5f43-405f-8109-c41eff03025a")));
Console.WriteLine("Guid To Bytes With Stack Allocation: " + GuidToByteStringStackAllocation(Guid.NewGuid()));
Console.WriteLine("Guid With different format: " + GuidToString(Guid.NewGuid(),"B"));