
namespace SwaggerBaseUri
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(option =>
                {
                    option.RouteTemplate = "codeMaze/{documentName}/swagger.json";
                });

                app.UseSwaggerUI(option =>
                {
                    option.SwaggerEndpoint("/codeMaze/v1/swagger.json", "CodeMaze API");
                    option.RoutePrefix = "codeMaze";
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}