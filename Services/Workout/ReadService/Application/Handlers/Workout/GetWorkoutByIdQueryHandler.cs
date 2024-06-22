using Application.Interfaces;
using Application.Models;
using Application.Querys.Workout.Get;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers.Workout;

public class GetWorkoutByIdQueryHandler : CommandHandler<GetWorkoutByIdQuery, GetWorkoutByIdResponse>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly AutoMapper.IMapper _mapper;


    public GetWorkoutByIdQueryHandler(IWorkoutRepository workoutRepository, AutoMapper.IMapper mapper)
    {
        _workoutRepository = workoutRepository;
        _mapper = mapper;
    }

    public override async Task<GetWorkoutByIdResponse> ExecuteAsync(GetWorkoutByIdQuery command, CancellationToken cancellationToken = default)
    {
        WorkoutModel mappedWorkout = new();
        try
        {
            Domain.Models.Workout workout = await _workoutRepository.GetWorkoutById(command.WorkoutId, cancellationToken);
            mappedWorkout = _mapper.Map<WorkoutModel>(workout);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message, StatusCodes.Status404NotFound);
        }

        return new GetWorkoutByIdResponse(mappedWorkout);
    }
}
