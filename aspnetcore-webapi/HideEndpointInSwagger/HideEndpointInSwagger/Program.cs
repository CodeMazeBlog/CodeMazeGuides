using HideEndpointInSwagger.Conventions;
using HideEndpointInSwagger.Filters;

namespace HideEndpointInSwagger;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers(s =>
           s.Conventions.Add(new HideControllerConvention()
           ));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.DocumentFilter<SwaggerDocumentFilter>();
            c.DocInclusionPredicate((docName, apiDesc) =>
            {
                var routeTemplate = apiDesc.RelativePath;

                if (routeTemplate == "WeatherForecast/GetWeatherForecast")
                    return false;

                return true;
            });
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