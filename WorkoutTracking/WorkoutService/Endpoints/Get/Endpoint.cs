using FastEndpoints;

namespace WorkoutService.Endpoints.Get;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/workout/{WorkoutId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        Console.WriteLine("not implemented yet");
    }
}
