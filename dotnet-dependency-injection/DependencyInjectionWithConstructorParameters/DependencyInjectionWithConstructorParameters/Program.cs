using DependencyInjectionWithConstructorParameters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {        
        services.Configure<CowOptions>(context.Configuration.GetSection("CowSettings"));
        services.AddScoped<IDogSoundService, DogSoundService>();
        services.AddScoped<IAnimalSoundService, AnimalSoundService>(
            serviceProvider => new AnimalSoundService(
                    dogSoundService: serviceProvider.GetRequiredService<IDogSoundService>(),
                    configuration: serviceProvider.GetRequiredService<IConfiguration>(),
                    options: serviceProvider.GetRequiredService<IOptions<CowOptions>>(),
                    sheepSound: "Baa")
            );
    })
    .Build();

var service = host.Services.GetRequiredService<IAnimalSoundService>();
service.Play();