using FastEndpoints;

namespace Application.Commands.Exercise.Post;

public record AddNewExerciseCommand(
    int WorkoutId, 
    string Name
    ) : ICommand<AddNewExerciseResponse>;
