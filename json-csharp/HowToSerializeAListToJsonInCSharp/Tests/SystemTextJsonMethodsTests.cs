using HowToSerializeAListToJsonInCSharp;

namespace Tests
{
    public class SystemTextJsonMethodsTests
    {
        private static readonly List<Club> _englishClubs = new()
            {
                new Club
                {
                    Name = "Arsenal",
                    YearFounded = 1886,
                    Country = "England",
                    NumberOfPlayers = "26",
                },
                new Club
                {
                    Name = "Manchester City",
                    YearFounded = 1880,
                    Country = "England",
                    NumberOfPlayers = "25",
                },
                new Club
                {
                    Name = "Sunderland",
                    YearFounded = 1879,
                    Country = "England",
                    NumberOfPlayers = "30",
                }
            };

        private readonly SerializeListToJsonWithSystemTextJson _serializeList
            = new(_englishClubs);

        private readonly string _expectedResult
            = """
                [
                  {
                    "name": "Arsenal",
                    "yearFounded": 1886,
                    "country": "England",
                    "numberOfPlayers": "26"
                  },
                  {
                    "name": "Manchester City",
                    "yearFounded": 1880,
                    "country": "England",
                    "numberOfPlayers": "25"
                  },
                  {
                    "name": "Sunderland",
                    "yearFounded": 1879,
                    "country": "England",
                    "numberOfPlayers": "30"
                  }
                ]
                """;

        [Fact]
        public void GivenAList_WhenUsingTheSerializeMethod_ThenReturnsAJsonString()
        {
            var englishClubsJson = _serializeList.SerializeMethod();

            Assert.Equal(_expectedResult, englishClubsJson);
        }

        [Fact]
        public void GivenAList_WhenUsingTheSerializeToUtf8BytesMethod_ThenReturnsAJsonString()
        {
            var englishClubsJson = _serializeList.SerializeToUtf8BytesMethod();

            Assert.Equal(_expectedResult, englishClubsJson);
        }
    }
}