using Application.Interfaces;
using Application.Querys.Workout.Get;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers.Workout;

public class GetWorkoutByIdQueryHandler : CommandHandler<GetWorkoutByIdQuery, GetWorkoutByIdResponse>
{
    private readonly IWorkoutRepository _workoutRepository;

    public GetWorkoutByIdQueryHandler(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public override async Task<GetWorkoutByIdResponse> ExecuteAsync(GetWorkoutByIdQuery command, CancellationToken cancellationToken = default)
    {
        Domain.Models.Workout workout = new();
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
