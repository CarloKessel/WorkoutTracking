using Application.Interfaces;
using Application.Models;
using Application.Querys.Exercise.Get;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers.Exercise;

public class GetExercisesByWorkoutIdHandler : CommandHandler<GetExercisesByWorkoutIdQuery, GetExercisesByWorkoutIdResponse>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly AutoMapper.IMapper _mapper;

    public GetExercisesByWorkoutIdHandler(IExerciseRepository exerciseRepository, AutoMapper.IMapper mapper)
    {
        _exerciseRepository = exerciseRepository;
        _mapper = mapper;
    }

    public override async Task<GetExercisesByWorkoutIdResponse> ExecuteAsync(GetExercisesByWorkoutIdQuery command, CancellationToken cancellationToken = default)
    {
        List<ExerciseModel> mappedExercises = new();
        try
        {
            List<Domain.Models.Exercise> exercise = await _exerciseRepository.GetExercisesByWorkoutId(command.WorkoutId, cancellationToken);
            mappedExercises = _mapper.Map<List<ExerciseModel>>(exercise);
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message, StatusCodes.Status404NotFound);
        }

        return new GetExercisesByWorkoutIdResponse(mappedExercises);
    }
}
