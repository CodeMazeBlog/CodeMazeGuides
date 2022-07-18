using Refit;
using RefitLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services
        .AddRefitClient<IUsersClient>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"));
    }).Build();

var usersClient = host.Services.GetRequiredService<IUsersClient>();
var users = await usersClient.GetAll();

foreach (var user in users)
{
    Console.WriteLine(user);
}

var newUser = new User { Name = "John Doe", Email = "john.doe@test.com" }; 
var userId = (await usersClient.CreateUser(newUser)).Id; 

Console.WriteLine($"User with Id: {userId} created");

var existingUser = await usersClient.GetUser(1);
existingUser.Email = "john.doe@gmail.com";

var updatedUser = await usersClient.UpdateUser(existingUser.Id, existingUser); 
Console.WriteLine($"User email updated to {updatedUser.Email}"); 

await usersClient.DeleteUser(userId); 
Console.WriteLine("User deleted");

public partial class Program { }
