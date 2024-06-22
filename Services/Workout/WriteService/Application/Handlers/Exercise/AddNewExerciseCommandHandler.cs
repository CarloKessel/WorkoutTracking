using Application.Commands.Exercise.Post;
using Application.Interfaces;
using Application.MessageBroker.Messages;
using FastEndpoints;

namespace Application.Handlers.Exercise;

public class AddNewExerciseCommandHandler : CommandHandler<AddNewExerciseCommand, AddNewExerciseResponse>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IMessageBrokerConnection _messageBrokerConnection;

    public AddNewExerciseCommandHandler(IExerciseRepository exerciseRepository, IMessageBrokerConnection messageBrokerConnection)
    {
        _exerciseRepository = exerciseRepository;
        _messageBrokerConnection = messageBrokerConnection;
    }

    public override async Task<AddNewExerciseResponse> ExecuteAsync(AddNewExerciseCommand command, CancellationToken cancellationToken = default)
    {
        var exercise = new Domain.Models.Exercise()
        {
            WorkoutId = command.WorkoutId,
            Name = command.Name
        };

        var storedExerciseId = await _exerciseRepository.CreateExercise(exercise, cancellationToken);

        ExerciseCreatedMessage exerciseCreatedMessage = new ExerciseCreatedMessage(_messageBrokerConnection);
        exerciseCreatedMessage.SendMessage(exercise);

        return new AddNewExerciseResponse(storedExerciseId);
    }
}
