using Refit;

namespace RefitLibrary;

[Headers("User-Agent: CodeMaze-Sample")]
public interface IUsersClient
{
    [Get("/users")]
    Task<IEnumerable<User>> GetAll();

    [Get("/users")]
    Task<IEnumerable<User>> GetAll([Query] string? name, CancellationToken token);

    [Get("/users/{id}")]
    Task<User> GetUser(int id);

    [Get("/users/{id}")]
    Task<ApiResponse<User>> GetUserResponse(int id);

    [Post("/users")]
    Task<User> CreateUser([Body] User user);

    [Put("/users/{id}")]
    Task<User> UpdateUser(int id, [Body] User user);

    [Delete("/users/{id}")]
    Task DeleteUser(int id);
}