using FastEndpoints;
using WorkoutService.Interfaces;
using WorkoutService.Models;
using WorkoutService.Querys.Get;

namespace WorkoutService.Handlers.Get;

public class GetWorkoutByIdQueryHandler : CommandHandler<GetWorkoutByIdQuery, GetWorkoutByIdResponse>
{
    private readonly IWorkoutRepository _workoutRepository;

    public GetWorkoutByIdQueryHandler(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public override async Task<GetWorkoutByIdResponse> ExecuteAsync(GetWorkoutByIdQuery command, CancellationToken cancellationToken = default)
    {
        Workout workout = new();
        try
        {
            workout = await _workoutRepository.GetWorkoutById(command.WorkoutId, cancellationToken);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message, StatusCodes.Status404NotFound);
        }

        return new GetWorkoutByIdResponse(workout.Name);
    }
}
