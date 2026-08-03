namespace HstsExample;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHsts(options =>
        {
            options.MaxAge = TimeSpan.FromDays(365);
            options.IncludeSubDomains = true;
            options.Preload = true;
        });

        //builder.Services.AddHttpsRedirection(options =>
        //{
        //    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
        //    options.HttpsPort = 443;
        //});

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseHsts();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
