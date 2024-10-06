using BlogsAPI;
using Carter;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCarter(configurator: c =>
        {
            c.WithResponseNegotiator<XmlNegotiator>();
        });

        var app = builder.Build();
        app.MapCarter();
        app.UseHttpsRedirection();
        app.Run();
    }
}