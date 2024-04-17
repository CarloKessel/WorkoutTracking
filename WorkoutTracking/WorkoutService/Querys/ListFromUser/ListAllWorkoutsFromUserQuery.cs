using FastEndpoints;

namespace WorkoutService.Querys.ListFromUser;

public record ListAllWorkoutsFromUserQuery(
    Guid UserId
    ) : ICommand<ListAllWorkoutsFromUserResponse>;
