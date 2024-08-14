using AutoMapper;
using Schedule.Application.Dto;
using Schedule.Application.Dto.WebDto;

namespace Schedule.Application.Schedule.Mapper;

public class ScheduleDlhDtoMapperProfile : Profile
{
    public ScheduleDlhDtoMapperProfile()
    {
        CreateMap<DateLessonsHomeworkDb, DateLessonsHomeworkWebDto>().ReverseMap()
            .ForMember(dthDb => dthDb.Day,
                expression => expression.MapFrom(dtoWeb => dtoWeb.Day))
            .ForMember(dthDb => dthDb.Id, 
                expression => expression.MapFrom(dthWeb => dthWeb.Id));
    }
}