namespace HowToUseRequestTimeoutsMiddleware.Services;

public interface IStarWarsService
{
    Task<Character> GetCharacterAsync(CancellationToken cancellationToken);
}
