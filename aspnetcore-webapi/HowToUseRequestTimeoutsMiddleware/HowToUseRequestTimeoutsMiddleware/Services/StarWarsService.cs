using HowToUseRequestTimeoutsMiddleware.Data;

namespace HowToUseRequestTimeoutsMiddleware.Services;

public class StarWarsService : IStarWarsService
{
    public async Task<Character> GetCharacterAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(2000, cancellationToken);

        return new()
        {
            Name = "Luke Skywalker",
            Height = 172,
            BirthYear = "19BBY",
            Gender = "Male"
        };
    }
}
