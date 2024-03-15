namespace ReadArraysFromAppSettings;

public partial class Endpoints
{
    public const string GetUsersEndpointName = "api/config/users";
    public const string GetUsersV2EndpointName = "api/v2/config/users";

    public static IEnumerable<User> GetUsersArrayFromAppSettings(IConfiguration configuration)
    {
        IConfigurationSection usersSection = configuration.GetSection("AppSettings:Users");
        IEnumerable<IConfigurationSection> usersArray = usersSection.GetChildren();

        return usersArray.Select(configSection => 
            new User 
            (
                Id: int.Parse(configSection["Id"]!.ToString()),
                Name: configSection["Name"]!.ToString(),
                Role: configSection["Role"]!.ToString())
            );
    }

    public static List<User>? GetUsersArrayFromAppSettingsV2(IConfiguration configuration)
    {
        return configuration.GetSection("AppSettings:Users").Get<List<User>>();
    }
}