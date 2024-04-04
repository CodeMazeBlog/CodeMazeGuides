using AutoMapper;
using AutoMapper.Internal;
using GettingPropertyMappingsWithAutomapper;


var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MyProfile()); });

var mapper = config.CreateMapper();
var source = new SourceClass { Name = "Jack", Age = 20 };
var destination = mapper.Map<SourceClass, DestinationClass>(source);
Console.WriteLine($"Name: {destination.FullName}, Age: {destination.YearsOld}");

var typeMaps = mapper.ConfigurationProvider.Internal().GetAllTypeMaps();
foreach (var typeMapType in typeMaps)
{
    Console.WriteLine($"Source Type: {typeMapType.SourceType.Name}");
    Console.WriteLine($"Destination Type: {typeMapType.DestinationType.Name}");
    foreach (var memberMap in typeMapType.MemberMaps)
    {
        var sourceProperty = memberMap.SourceMember.Name;
        Console.WriteLine($"Source Property: {sourceProperty}");
        Console.WriteLine($"Destination Property: {memberMap}");
    }
}

