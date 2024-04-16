using FastEndpoints;

namespace WorkoutService.Endpoints.GetAll;

public class Endpoint : EndpointWithoutRequest<Response>
{
    public override void Configure()
    {
        Get("/workout/{UserId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
