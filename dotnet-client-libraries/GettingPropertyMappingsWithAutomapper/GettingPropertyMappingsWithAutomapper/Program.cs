using AutoMapper;
using AutoMapper.Internal;
using GettingPropertyMappingsWithAutomapper;


var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MyProfile()); });

var mapper = config.CreateMapper();
var source = new Source { Name = "Jack", Age = 20 };
var destination = mapper.Map<Source, Destination>(source);
Console.WriteLine($"Name: {destination.FullName}, Age: {destination.YearsOld}");

var typeMaps = mapper.ConfigurationProvider.Internal().GetAllTypeMaps();
foreach (var typeMap in typeMaps)
{
    Console.WriteLine($"Source Type: {typeMap.SourceType.Name}");
    Console.WriteLine($"Destination Type: {typeMap.DestinationType.Name}");
    foreach (var memberMap in typeMap.MemberMaps)
    {
        var sourceProperty = memberMap.SourceMember.Name;
        Console.WriteLine($"Source Property: {sourceProperty}");
        Console.WriteLine($"Destination Property: {memberMap}");
    }
}

