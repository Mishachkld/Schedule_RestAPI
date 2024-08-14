using AutoMapper;
using Schedule.Application.Dto;
using Schedule.Application.Dto.WebDto;

namespace Schedule.Application.Schedule.Mapper;

public class IMapWith
{
    public static DateLessonsHomeworkWebDto WebDto(IMapper mapper, DateLessonsHomeworkDb mapItem)
    {
        var mappedWebDto = mapper.Map<DateLessonsHomeworkWebDto>(mapItem);
        var list = mappedWebDto.DataDlh = [];
        list.AddRange(mapItem.DataDlh.Select(scheduleItem =>
            mapper.Map<LessonHomeworkWebDto>(scheduleItem)));

        return mappedWebDto;
    }

    public static DateLessonsHomeworkDb DbDto(IMapper mapper, DateLessonsHomeworkWebDto mapItem)
    {
        var mappedDbDto = mapper.Map<DateLessonsHomeworkDb>(mapItem);
        var list = mappedDbDto.DataDlh = [];
        list.AddRange(mapItem.DataDlh.Select(scheduleItem =>
            mapper.Map<LessonHomeworkDb>(scheduleItem)));

        return mappedDbDto;
    }

    public static List<DateLessonsHomeworkWebDto> WebDtoList(IMapper mapper, List<DateLessonsHomeworkDb> dbList)
    {
        var webDtoList = new List<DateLessonsHomeworkWebDto>();
        webDtoList.AddRange(dbList.Select(
            item => WebDto(mapper, item)));
        return webDtoList;
    } 
    public static List<DateLessonsHomeworkDb> DbDtoList(IMapper mapper, List<DateLessonsHomeworkWebDto> dbList)
    {
        var dbDtoList = new List<DateLessonsHomeworkDb>();
        dbDtoList.AddRange(dbList.Select(
            item => DbDto(mapper, item)));
        return dbDtoList;
    }
}