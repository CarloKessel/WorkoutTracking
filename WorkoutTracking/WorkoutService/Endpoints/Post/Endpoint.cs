using FastEndpoints;

namespace WorkoutService.Endpoints.Post;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/workout");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Console.WriteLine(req.Name);
    }
}
