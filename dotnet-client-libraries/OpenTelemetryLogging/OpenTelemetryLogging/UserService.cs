using Microsoft.Extensions.Logging;

namespace OpenTelemetryLogging;

public class UserService : IUserSevice
{
    private static readonly List<User> _users = new()
    {
        new User("codemaze", "Pa$$w0rd!!")
    };

    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public bool Login(string username, string password)
    { 
        using var _ = _logger.BeginScope(new List<KeyValuePair<string, object>>
        {
            new KeyValuePair<string, object>("UserName", username)
        });

        _logger.LogInformation("Searching for user");

        if (_users.Any(u => u.Equals(new(username, password))))
        {

            _logger.LogInformation("User found, logging in");
            return true;
        }

        _logger.LogWarning("User not found");
        return false;
    }
}