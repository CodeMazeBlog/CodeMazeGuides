
using SagaPattern.Repositories;
using SagaPattern.Saga.Messages;
using System.Text.Json.Serialization;

namespace SagaPattern
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

            // Setup NServiceBus host
            builder.Host.UseNServiceBus(context =>
            {
                var endpointConfiguration = new EndpointConfiguration("OrderEndpoint");
                var transport = endpointConfiguration.UseTransport<LearningTransport>();
                var persistence = endpointConfiguration.UsePersistence<LearningPersistence>();
                var routing = transport.Routing();
                routing.RouteToEndpoint(typeof(StartOrder), "OrderEndpoint");

                return endpointConfiguration;
            });
            
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
        }
    }
}