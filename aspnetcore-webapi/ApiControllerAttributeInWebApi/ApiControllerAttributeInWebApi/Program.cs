using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

[assembly: ApiController]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(opt =>
    {
        opt.InvalidModelStateResponseFactory = context =>
        {
            var responseObj = new
            {
                path = context.HttpContext.Request.Path.ToString(),
                method = context.HttpContext.Request.Method,
                controller = (context.ActionDescriptor as ControllerActionDescriptor)?.ControllerName,
                action = (context.ActionDescriptor as ControllerActionDescriptor)?.ActionName,
                errors = context.ModelState.Keys.Select(k =>
                {
                    return new
                    {
                        field = k,
                        Messages = context.ModelState[k]?.Errors.Select(e => e.ErrorMessage)
                    };
                })
            };

            return new BadRequestObjectResult(responseObj);
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

public partial class Program { }
