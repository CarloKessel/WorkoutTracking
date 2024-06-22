using Application.Interfaces;
using Application.Models;
using Application.Querys.Workout.List;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers.Workout;

public class GetAllWorkoutsByUserEmailHandler : CommandHandler<GetAllWorkoutsByUserEmailQuery, GetAllWorkoutsByUserEmailResponse>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly AutoMapper.IMapper _mapper;

    public GetAllWorkoutsByUserEmailHandler(IWorkoutRepository workoutRepository, AutoMapper.IMapper mapper)
    {
        _workoutRepository = workoutRepository;
        _mapper = mapper;
    }

    public override async Task<GetAllWorkoutsByUserEmailResponse> ExecuteAsync(GetAllWorkoutsByUserEmailQuery command, CancellationToken cancellationToken = default)
    {
        List<WorkoutModel> mappedWorkouts = new List<WorkoutModel>();
        try
        {
            List<Domain.Models.Workout> workouts = await _workoutRepository.ListAllWorkoutsFromUserEmail(command.UserEmail, cancellationToken);
            mappedWorkouts = _mapper.Map<List<WorkoutModel>>(workouts);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message, StatusCodes.Status404NotFound);
        }

        return new GetAllWorkoutsByUserEmailResponse(mappedWorkouts);
    }
}
