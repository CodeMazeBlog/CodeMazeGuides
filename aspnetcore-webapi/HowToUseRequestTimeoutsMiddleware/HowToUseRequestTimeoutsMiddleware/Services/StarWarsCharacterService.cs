using HowToUseRequestTimeoutsMiddleware.Data;

namespace HowToUseRequestTimeoutsMiddleware.Services;

public class StarWarsCharacterService : ICharacterService
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
