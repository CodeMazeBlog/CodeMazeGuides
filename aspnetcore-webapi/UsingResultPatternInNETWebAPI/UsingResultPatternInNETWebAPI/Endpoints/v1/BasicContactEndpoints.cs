namespace UsingResultPatternInNETWebAPI.Endpoints;

public static class BasicContactEndpoints
{
    public static void MapBasicContactEndpoints(this IEndpointRouteBuilder app)
    {
        var contacts = app.MapGroup("api/v1/contacts");

        contacts.MapGet("/", (BasicContactService contactService) =>
            Results.Ok(contactService.GetAll()));

        contacts.MapGet("/{id:guid}", (Guid id, BasicContactService contactService) =>
            Results.Ok(contactService.GetById(id)));

        contacts.MapPost("/", (CreateContactDto createContactDto, BasicContactService contactService) =>
        {
            var contactDto = contactService.Create(createContactDto);

            return Results.Created($"/api/v1/contacts/{contactDto.Id}", contactDto);
        });
    }
}
