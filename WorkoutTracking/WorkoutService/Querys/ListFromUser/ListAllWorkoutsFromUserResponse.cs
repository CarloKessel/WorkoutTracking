using WorkoutService.Models;

namespace WorkoutService.Querys.ListFromUser;

public record ListAllWorkoutsFromUserResponse(
    List<Workout> Workouts
    );
