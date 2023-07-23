namespace HowToSerializeAListToJsonInCSharp
{
    public partial class GenerateBenchmarkData
    {
        public static List<Club> Generate10000ListsForBenchmark()
        {
            List<Club> englishClubs = new();
            for (int i = 0; i < 10000; i++)
            {
                var club = new Club
                {
                    Name = $"Club-{i}",
                    YearFounded = 1000 + i,
                    Country = "England",
                    NumberOfPlayers = "30",
                };
                englishClubs.Add(club);
            }

            return englishClubs;
        }
    }
}