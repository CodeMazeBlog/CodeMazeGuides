// See https://aka.ms/new-console-template for more information
using DependencyInjectionLifetimeScopes;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Registering Service as Transient");
var transientServiceProvider = new ServiceCollection()
    .AddTransient<IMyService, MyService>()
    .BuildServiceProvider();

var transientInstance1 = transientServiceProvider.GetService<IMyService>();
var transientInstance2 = transientServiceProvider.GetService<IMyService>();

Console.WriteLine($"Transient Instance 1 == Transient Instance 2 : {transientInstance1.Equals(transientInstance2)}");


Console.WriteLine("Registering Service as Singleton");
var singletonServiceProvider = new ServiceCollection()
    .AddSingleton<IMyService, MyService>()
    .BuildServiceProvider();

var singletonInstance1 = singletonServiceProvider.GetService<IMyService>();
var singletonInstance2 = singletonServiceProvider.GetService<IMyService>();

Console.WriteLine($"Singleton Instance 1 == Singleton Instance 2 : {singletonInstance1.Equals(singletonInstance2)}");

Console.WriteLine("Registering Service as Scoped");
var scopedServiceProvider = new ServiceCollection()
    .AddScoped<IMyService, MyService>()
    .BuildServiceProvider();

var serviceScopeFactory = scopedServiceProvider.GetRequiredService<IServiceScopeFactory>();

IMyService scope1Instance1;
IMyService scope1Instance2;
IMyService scope2Instance1;

using (var scope1 = serviceScopeFactory.CreateScope())
{
    scope1Instance1 = scope1.ServiceProvider.GetService<IMyService>();
    scope1Instance2 = scope1.ServiceProvider.GetService<IMyService>();
}

using (var scope2 = serviceScopeFactory.CreateScope())
{
    scope2Instance1 = scope2.ServiceProvider.GetService<IMyService>();
}

Console.WriteLine($"Scope 1 Instance 1 == Scope 1 Instance 2 :{scope1Instance1.Equals(scope1Instance2)}");
Console.WriteLine($"Scope 1 Instance 1 == Scope 2 Instance 1 :{scope1Instance1.Equals(scope2Instance1)}");




