using IntroductionToScrutorInDotNet.Customers.Services;
using IntroductionToScrutorInDotNet.Entities;
using IntroductionToScrutorInDotNet.Repositories;
using IntroductionToScrutorInDotNet.Repositories.Decorators;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Scan(selector => selector
    .FromCallingAssembly()
    .AddClasses(
        classSelector =>
            classSelector.InNamespaces("IntroductionToScrutorInDotNet.Services.Implementations")
    )
    .AsImplementedInterfaces()
);

builder.Services.Scan(selector => selector
    .FromAssemblyOf<ICustomerService>()
    .AddClasses(classSelector =>
        classSelector.AssignableTo<ICustomerService>())
    .AsMatchingInterface()
    .WithTransientLifetime()
);

builder.Services.Scan(selector => selector
    .FromCallingAssembly()
    .AddClasses(classSelector => classSelector.AssignableTo(typeof(IRepository<>)))
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsImplementedInterfaces());

builder.Services.Decorate<IRepository<User>, RepositoryLoggerDecorator<User>>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}