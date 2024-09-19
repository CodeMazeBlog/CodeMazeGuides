using MediatR;
using MediatR.NotificationPublishers;
using MediatrParallelPublishing;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddMediatR(c =>
{
    c.RegisterServicesFromAssemblyContaining<Program>();
    c.NotificationPublisher = new TaskWhenAllPublisher();
});

var serviceProvider = services.BuildServiceProvider();

var mediator = serviceProvider.GetRequiredService<IMediator>();

await mediator.Publish(new Notification("Hello, World!"));