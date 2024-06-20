using Application.Models;

namespace Application.Querys.Workout.List;

public record GetAllWorkoutsByUserEmailResponse(
    List<WorkoutModel> Workouts
    );
