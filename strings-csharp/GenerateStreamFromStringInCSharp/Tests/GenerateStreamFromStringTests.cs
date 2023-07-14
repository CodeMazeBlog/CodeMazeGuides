using GenerateStreamFromStringInCSharp;

namespace Tests
{
    public class GenerateStreamFromStringTests
    {
        private readonly string _testString
        = """
        Sed facilisis justo quam, ornare varius tellus dapibus sit amet. Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
        Nullam aliquam auctor fringilla. Nam id orci lacus. Sed placerat justo vitae sem auctor, ac molestie lacus sodales. 
        Nullam tincidunt lacus ex, ac hendrerit elit tincidunt in. Integer tincidunt accumsan nisl, id aliquet leo convallis in. 
        Morbi pulvinar odio et est vulputate viverra. Maecenas nibh libero, sollicitudin quis ex ut, egestas auctor mi. 
        Fusce varius facilisis mauris, ut volutpat libero volutpat in. Aliquam faucibus hendrerit nibh vel porttitor.
        """;

        [Fact]
        public void WhenUsingGenerateStreamFromString_ThenReturnsStream()
        {
            Stream resultStream = GenerateStreamFromStringMethods.GenerateStreamFromString(_testString);

            Assert.NotNull(resultStream);
            Assert.IsAssignableFrom<Stream>(resultStream);
        }

        [Fact]
        public void WhenUsingConciselyGenerateStreamFromString_ThenReturnsStream()
        {
            Stream resultStream = GenerateStreamFromStringMethods.ConciselyGenerateStreamFromString(_testString);

            Assert.NotNull(resultStream);
            Assert.IsAssignableFrom<Stream>(resultStream);
        }
    }
}