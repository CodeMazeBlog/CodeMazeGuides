using Carter;
using Carter.ModelBinding;
using Carter.Response;
using IntroductionToCarter.Contracts;
using IntroductionToCarter.Services.Abstractions;
using System.Net;

namespace IntroductionToCarter.Modules;

public class BookModule : CarterModule
{
    public BookModule()
        : base("/api")
    {
        WithTags("Books");
        IncludeInOpenApi();
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/books", async (IBookService service) =>
        {
            var books = await service.GetAllAsync();

            return Results.Ok(books);
        });

        app.MapGet("/books/{id:guid}", async (Guid id, IBookService service) =>
        {
            var book = await service.GetByIdAsync(id);

            return Results.Ok(book);
        });

        app.MapPost("/books", async (
            HttpContext context,
            CreateBookRequest request,
            IBookService service) =>
        {
            var result = context.Request.Validate(request);

            if (!result.IsValid)
            {
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                await context.Response.Negotiate(result.GetFormattedErrors());

                return Results.UnprocessableEntity();
            }

            var book = await service.CreateAsync(request);

            return Results.Created($"/api/books/{book.Id}", book);
        });

        app.MapPut("/books/{id:guid}", async (
            Guid id,
            HttpContext context,
            UpdateBookRequest request,
            IBookService service) =>
        {
            var result = context.Request.Validate(request);

            if (!result.IsValid)
            {
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                await context.Response.Negotiate(result.GetFormattedErrors());

                return Results.UnprocessableEntity();
            }

            await service.UpdateAsync(id, request);

            return Results.NoContent();
        });

        app.MapDelete("/books/{id:guid}", async (Guid id, IBookService service) =>
        {
            await service.DeleteAsync(id);

            return Results.NoContent();
        });
    }
}
