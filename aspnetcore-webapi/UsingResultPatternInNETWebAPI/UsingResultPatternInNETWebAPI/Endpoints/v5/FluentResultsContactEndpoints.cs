namespace UsingResultPatternInNETWebAPI.Endpoints;

public static class FluentResultsContactEndpoints
{
    public static void MapFluentResultsContactEndpoints(this IEndpointRouteBuilder app)
    {
        var contacts = app.MapGroup("api/v5/contacts");

        contacts.MapGet("/", (FluentResultsContactService contactService) =>
            Results.Ok(contactService.GetAll().Value));

        contacts.MapGet("/{id:guid}", (Guid id, FluentResultsContactService contactService) =>
        {
            var result = contactService.GetById(id);

            if (result.IsFailed)
            {
                return Results.Problem(statusCode: StatusCodes.Status404NotFound, detail: result.Errors[0].Message);
            }

            return Results.Ok(result.Value);
        });

        contacts.MapPost("/", (CreateContactDto createContactDto, FluentResultsContactService contactService) =>
        {
            var result = contactService.Create(createContactDto);

            if (result.IsFailed)
            {
                return Results.Problem(statusCode: StatusCodes.Status409Conflict, detail: result.Errors[0].Message);
            }

            return Results.Created($"/api/v5/contacts/{result.Value.Id}", result.Value);
        });
    }
}
