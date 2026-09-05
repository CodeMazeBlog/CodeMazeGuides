using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using GlobalDefaultJsonSerializationoptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var controllers = builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.WriteIndented = false;
        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Default;
        options.JsonSerializerOptions.AllowTrailingCommas = true;
        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
    });

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.SerializerOptions.WriteIndented = false;
    options.SerializerOptions.Encoder = JavaScriptEncoder.Default;
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
});

// AddNewtonsoftJson() replaces both MVC formatters, so it would take the
// System.Text.Json configuration above out of play for every controller action.
// The sample demonstrates all three approaches, so this one is registered behind
// a configuration switch: run with UseNewtonsoftJson=true to serialize controller
// responses with Json.NET instead.
if (builder.Configuration.GetValue<bool>("UseNewtonsoftJson"))
{
    controllers.AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.Formatting = Formatting.Indented;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.DateFormatString = "dd-MM-yyyy";
        options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
    });
}

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("api/Product/create", (Product product) =>
{
    return product;
});

app.Run();

public partial class Program;
