using FastEndpoints;

namespace WorkoutService.Querys.ListFromUser;

public record ListAllWorkoutsFromUserQuery(
    string UserEmail
    ) : ICommand<ListAllWorkoutsFromUserResponse>;
