using BlogsAPI;
using Carter;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter(configurator: c =>
{
    c.WithResponseNegotiator<XmlNegotiator>();
});

var app = builder.Build();
app.MapCarter();
app.UseHttpsRedirection();
app.Run();

public partial class Program { }