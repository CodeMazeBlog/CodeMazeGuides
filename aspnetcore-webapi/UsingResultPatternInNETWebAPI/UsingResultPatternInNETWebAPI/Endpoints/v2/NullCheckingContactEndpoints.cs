namespace UsingResultPatternInNETWebAPI.Endpoints;

public static class NullCheckingContactEndpoints
{
    public static void MapNullCheckingContactEndpoints(this IEndpointRouteBuilder app)
    {
        var contacts = app.MapGroup("api/v2/contacts");

        contacts.MapGet("/", (NullCheckingContactService contactService) =>
            Results.Ok(contactService.GetAll()));

        contacts.MapGet("/{id:guid}", (Guid id, NullCheckingContactService contactService) =>
        {
            var contactDto = contactService.GetById(id);

            if (contactDto is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(contactDto);
        });

        contacts.MapPost("/", (CreateContactDto createContactDto, NullCheckingContactService contactService) =>
        {
            var contactDto = contactService.Create(createContactDto);

            if (contactDto is null)
            {
                return Results.BadRequest();
            }

            return Results.Created($"/api/v2/contacts/{contactDto.Id}", contactDto);
        });
    }
}
