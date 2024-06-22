using FastEndpoints;

namespace Application.Commands.Exercise.Post;

public record AddNewExerciseCommand(
    Guid WorkoutId, 
    string Name
    ) : ICommand<AddNewExerciseResponse>;
