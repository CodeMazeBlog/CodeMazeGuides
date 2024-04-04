namespace Test
{
    [TestClass]
    public class GettingPropertyMappingsWithAutomapperTest
    {
        private IMapper mapper = null;
        public GettingPropertyMappingsWithAutomapperTest()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MyProfile()); });
            mapper = config.CreateMapper();
        }

        [TestMethod]
        public void WhenSourceMapsToDestinationThenEqualValuesUnitTest()
        {
            var source = new Source { Name = "Jack", Age = 20 };
            var destination = mapper.Map<Source, Destination>(source);

            Assert.AreEqual(source.Name,destination.FullName);
            Assert.AreEqual(source.Age,destination.YearsOld);
        }

        [TestMethod]
        public void WhenGettingMappingsThenCorrectMappingUnitTest()
        {
            var typeMaps = mapper.ConfigurationProvider.Internal().GetAllTypeMaps();
            
            Assert.AreEqual(typeMaps.First().SourceType.Name,nameof(Source));
            Assert.AreEqual(typeMaps.First().DestinationType.Name, nameof(Destination));
        }
    }
}