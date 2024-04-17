using FastEndpoints;
using WorkoutService.Interfaces;
using WorkoutService.Models;
using WorkoutService.Querys.ListFromUser;

namespace WorkoutService.Handlers.ListFromUser;

public class GetAllWorkoutsFromUserHandler : CommandHandler<ListAllWorkoutsFromUserQuery, ListAllWorkoutsFromUserResponse>
{
    private readonly IWorkoutRepository _workoutRepository;

    public GetAllWorkoutsFromUserHandler(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async override Task<ListAllWorkoutsFromUserResponse> ExecuteAsync(ListAllWorkoutsFromUserQuery command, CancellationToken cancellationToken = default)
    {
        List<Workout> workouts = new();
        try
        {
            workouts = await _workoutRepository.ListAllWorkoutsFromUserId(command.UserId, cancellationToken);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message, StatusCodes.Status404NotFound);
        }

        return new ListAllWorkoutsFromUserResponse(workouts);
    }
}
