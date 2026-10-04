namespace UsingResultPatternInNETWebAPI.Endpoints;

public static class ExceptionsForFlowControlContactEndpoints
{
    public static void MapExceptionsForFlowControlContactEndpoints(this IEndpointRouteBuilder app)
    {
        var contacts = app.MapGroup("api/v3/contacts");

        contacts.MapGet("/", (ExceptionsForFlowControlContactService contactService) =>
            Results.Ok(contactService.GetAll()));

        contacts.MapGet("/{id:guid}", (Guid id, ExceptionsForFlowControlContactService contactService) =>
            Results.Ok(contactService.GetById(id)));

        contacts.MapPost("/", (CreateContactDto createContactDto, ExceptionsForFlowControlContactService contactService) =>
        {
            var contactDto = contactService.Create(createContactDto);

            return Results.Created($"/api/v3/contacts/{contactDto.Id}", contactDto);
        });
    }
}
