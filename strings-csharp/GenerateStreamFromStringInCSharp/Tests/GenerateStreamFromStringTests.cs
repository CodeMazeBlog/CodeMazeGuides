using GenerateStreamFromStringInCSharp;
using System.Text;

namespace Tests
{
    public class GenerateStreamFromStringTests
    {
        private const string TestString
        = """
        Sed facilisis justo quam, ornare varius tellus dapibus sit amet. Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
        Nullam aliquam auctor fringilla. Nam id orci lacus. Sed placerat justo vitae sem auctor, ac molestie lacus sodales. 
        Nullam tincidunt lacus ex, ac hendrerit elit tincidunt in. Integer tincidunt accumsan nisl, id aliquet leo convallis in. 
        Morbi pulvinar odio et est vulputate viverra. Maecenas nibh libero, sollicitudin quis ex ut, egestas auctor mi. 
        Fusce varius facilisis mauris, ut volutpat libero volutpat in. Aliquam faucibus hendrerit nibh vel porttitor.
        """;

        [Fact]
        public void WhenUsingMemoryStreamAndStreamWriter_ThenReturnsStream()
        {
            using var resultStream = GenerateStreamFromStringMethods.GetStreamWithStreamWriter(TestString);

            using var reader = new StreamReader(resultStream, Encoding.UTF8);
            var resultString = reader.ReadToEnd();

            Assert.Equal(TestString, resultString);
        }

        [Fact]
        public void WhenUsingGetBytesAndMemoryStream_ThenReturnsStream()
        {
            using var resultStream = GenerateStreamFromStringMethods.GetStreamWithGetBytes(TestString);

            using var reader = new StreamReader(resultStream, Encoding.UTF8);
            var resultString = reader.ReadToEnd();

            Assert.Equal(TestString, resultString);
        }
    }
}