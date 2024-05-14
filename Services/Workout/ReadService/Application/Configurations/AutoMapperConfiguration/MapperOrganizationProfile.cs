using AutoMapper;
using Application.Models;

namespace Application.Configurations.AutoMapperConfiguration;

public class MapperOrganizationProfile : Profile
{
    public MapperOrganizationProfile()
    {
        CreateMap<WorkoutModel, Domain.Models.Workout>();
        CreateMap<Domain.Models.Workout, WorkoutModel>();
    }
}
