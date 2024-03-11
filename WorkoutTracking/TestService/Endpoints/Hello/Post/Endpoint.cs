using FastEndpoints;

namespace TestService.Endpoints.Hello.Post;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/hello");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        await SendAsync(new()
        {
            ResponseBack = "Hello " + req.Name + ", how are you doing?"
        });
    }
}
