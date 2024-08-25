using FastEndpoints;

namespace REPRPattern;

public class BookEndpoint : Endpoint<BookEndpointRequest, BookEndpointResponse>
{
    public override void Configure()
    {
        Post("/api/book/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(BookEndpointRequest req, CancellationToken ct)
        => await SendAsync(new($"{req.Title} was written by {req.AuthorName}"), cancellation: ct);
}