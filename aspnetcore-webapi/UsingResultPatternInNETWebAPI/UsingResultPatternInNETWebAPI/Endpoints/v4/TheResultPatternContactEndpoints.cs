using UsingResultPatternInNETWebAPI.TheResultPattern;

namespace UsingResultPatternInNETWebAPI.Endpoints;

public static class TheResultPatternContactEndpoints
{
    public static void MapTheResultPatternContactEndpoints(this IEndpointRouteBuilder app)
    {
        var contacts = app.MapGroup("api/v4/contacts");

        contacts.MapGet("/", (TheResultPatternContactService contactService) =>
            Results.Ok(contactService.GetAll().Value));

        contacts.MapGet("/{id:guid}", (Guid id, TheResultPatternContactService contactService) =>
        {
            var result = contactService.GetById(id);

            if (!result.IsSuccess)
            {
                return result.ToProblem();
            }

            return Results.Ok(result.Value);
        });

        contacts.MapPost("/", (CreateContactDto createContactDto, TheResultPatternContactService contactService) =>
        {
            var result = contactService.Create(createContactDto);

            if (!result.IsSuccess)
            {
                return result.ToProblem();
            }

            var contactDto = result.Value;

            return Results.Created($"/api/v4/contacts/{contactDto.Id}", contactDto);
        });
    }
}
