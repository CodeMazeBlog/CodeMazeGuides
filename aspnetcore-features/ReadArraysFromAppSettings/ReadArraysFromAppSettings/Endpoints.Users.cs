namespace ReadArraysFromAppSettings;

public partial class Endpoints
{
    public const string GetUsersEndpointName = "api/config/users";
    public const string GetUsersV2EndpointName = "api/v2/config/users";

    public static object GetArrayFromAppSettings(IConfiguration configuration)
    {
        IConfigurationSection usersSection = configuration.GetSection("AppSettings:Users");
        IEnumerable<IConfigurationSection> usersArray = usersSection.GetChildren();
        return usersArray.Select(configSection => new
        {
            Id = int.Parse(configSection["Id"]!.ToString()),
            Name = configSection["Name"]!.ToString(),
            Role = configSection["Role"]!.ToString()
        });
    }

    public static List<User>? GetArrayFromAppSettingsV2(IConfiguration configuration)
    {
        return configuration.GetSection("AppSettings:Users").Get<List<User>>();
    }
}