using Application.Commands.Post;
using Application.Interfaces;
using Domain.Models;
using FastEndpoints;

namespace Application.Handlers.Post;

public class AddNewWorkoutCommandHandler : CommandHandler<AddNewWorkoutCommand, AddNewWorkoutResponse>
{
    private readonly IWorkoutRepository _workoutRepository;
    public AddNewWorkoutCommandHandler(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public override async Task<AddNewWorkoutResponse> ExecuteAsync(AddNewWorkoutCommand command, CancellationToken cancellationToken)
    {
        var workout = new Workout()
        {
            UserEmail = command.UserEmail,
            Name = command.Name
        };

        var storedWorkoutId = await _workoutRepository.CreateWorkout(workout, cancellationToken);

        return new AddNewWorkoutResponse(storedWorkoutId);
    }
}
