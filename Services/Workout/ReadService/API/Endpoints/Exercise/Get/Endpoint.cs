using Application.Querys.Exercise.Get;
using FastEndpoints;

namespace API.Endpoints.Exercise.Get;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("exercises/workout/{WorkoutId}");
        Permissions("read:exercises");
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var query = new GetExercisesByWorkoutIdQuery(request.WorkoutId);
        var response = await query.ExecuteAsync(cancellationToken);
        await SendOkAsync(new Response { Exercises = response.Exercises }, cancellationToken);
    }
}
