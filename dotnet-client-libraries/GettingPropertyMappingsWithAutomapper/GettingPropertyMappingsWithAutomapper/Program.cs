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
    foreach (var memberMap in typeMap.MemberMaps)
    {
        Console.WriteLine(
            $"{typeMap.SourceType.Name}.{memberMap.SourceMember.Name} "
            + $"is mapped to {typeMap.DestinationType.Name}.{memberMap}");
    }
}
