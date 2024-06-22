using Application.Commands.Workout.Post;
using Application.Interfaces;
using Application.MessageBroker.Messages;
using Domain.Models;
using FastEndpoints;

namespace Application.Handlers.Post;

public class AddNewWorkoutCommandHandler : CommandHandler<AddNewWorkoutCommand, AddNewWorkoutResponse>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IMessageBrokerConnection _messageBrokerConnection;

    public AddNewWorkoutCommandHandler(IWorkoutRepository workoutRepository, IMessageBrokerConnection messageBrokerConnection)
    {
        _workoutRepository = workoutRepository;
        _messageBrokerConnection = messageBrokerConnection;

    }

    public override async Task<AddNewWorkoutResponse> ExecuteAsync(AddNewWorkoutCommand command, CancellationToken cancellationToken)
    {
        var workout = new Workout()
        {
            UserEmail = command.UserEmail,
            Name = command.Name
        };

        var storedWorkoutId = await _workoutRepository.CreateWorkout(workout, cancellationToken);

        WorkoutCreatedMessage workoutCreatedMessage = new WorkoutCreatedMessage(_messageBrokerConnection);
        workoutCreatedMessage.SendMessage(workout);

        return new AddNewWorkoutResponse(storedWorkoutId);
    }
}
