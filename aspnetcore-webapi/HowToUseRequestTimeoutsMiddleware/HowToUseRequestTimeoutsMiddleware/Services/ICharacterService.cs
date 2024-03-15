using HowToUseRequestTimeoutsMiddleware.Data;

namespace HowToUseRequestTimeoutsMiddleware.Services;

public interface ICharacterService
{
    Task<Character> GetCharacterAsync(CancellationToken cancellationToken);
}
