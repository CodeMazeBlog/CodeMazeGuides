
using Confluent.Kafka;

namespace Kafka
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = "order-producer"
            };

            builder.Services.AddSingleton<IProducer<string, string>>(new ProducerBuilder<string, string>(producerConfig).Build());

            var app = builder.Build();

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
