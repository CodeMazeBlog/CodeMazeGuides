namespace Test;

[TestClass]
public class GettingPropertyMappingsWithAutomapperTest
{
    private readonly IMapper mapper;

    public GettingPropertyMappingsWithAutomapperTest()
    {
        var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MyProfile()); });
        mapper = config.CreateMapper();
    }

    [TestMethod]
    public void GivenMappedTypes_WhenSourceIsMappedToDestination_ThenValuesAreMappedCorrectly()
    {
        var source = new Source { Name = "Jack", Age = 20 };
        var destination = mapper.Map<Source, Destination>(source);

        Assert.AreEqual(source.Name, destination.FullName);
        Assert.AreEqual(source.Age, destination.YearsOld);
    }

    [TestMethod]
    public void GivenMappedTypes_WhenGettingAllMappedTypes_ThenMappedTypesAreCorrect()
    {
        var typeMaps = mapper.ConfigurationProvider.Internal().GetAllTypeMaps();

        Assert.AreEqual(nameof(Source), typeMaps.First().SourceType.Name);
        Assert.AreEqual(nameof(Destination), typeMaps.First().DestinationType.Name);
    }
}