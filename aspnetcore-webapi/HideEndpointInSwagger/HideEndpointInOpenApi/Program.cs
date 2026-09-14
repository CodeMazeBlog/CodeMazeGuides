using HideEndpointInOpenApi.Conventions;
using HideEndpointInOpenApi.Transformers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(s =>
   s.Conventions.Add(new HideActionConvention()
   ));

builder.Services.AddOpenApi(options =>
{
    options.ShouldInclude = apiDesc => apiDesc.RelativePath != "WeatherForecast/GetWeatherForecast";
    options.AddDocumentTransformer<HideEndpointDocumentTransformer>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/internal", () => "internal").ExcludeFromDescription();

app.Run();
