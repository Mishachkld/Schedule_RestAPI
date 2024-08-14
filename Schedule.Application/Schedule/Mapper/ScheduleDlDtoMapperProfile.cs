using AutoMapper;
using Schedule.Application.Dto;
using Schedule.Application.Dto.WebDto;

namespace Schedule.Application.Schedule.Mapper;

public class ScheduleDlDtoMapperProfile : Profile
{
    public ScheduleDlDtoMapperProfile()
    {
        CreateMap<LessonHomeworkDb, LessonHomeworkWebDto>().ReverseMap()
            .ForMember(dthDb => dthDb.Lesson,
                expression => expression.MapFrom(dthWeb => dthWeb.Lesson))
            .ForMember(dthDb => dthDb.Homework,
                expression => expression.MapFrom(dtoWeb => dtoWeb.Homework))
            .ForMember(dthDb => dthDb.NumberLesson, 
                expression => expression.MapFrom(dthWeb => dthWeb.NumberLesson))
            ;
    }
}