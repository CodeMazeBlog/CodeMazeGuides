using Swashbuckle.AspNetCore.Filters;

namespace EfCoreInterceptors;

public class UserExample : IExamplesProvider<AddUserRequest>
{
    public AddUserRequest GetExamples() => new("jason.st56", "jason.st56@gmail.com");
}