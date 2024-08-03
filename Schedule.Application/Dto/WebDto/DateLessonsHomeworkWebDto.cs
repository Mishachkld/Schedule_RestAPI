namespace Schedule.Application.Dto.WebDto;

public class DateLessonsHomeworkWebDto
{
    public Guid Id { get; set; }
    public DateTime Day { get; set; }
    public List<LessonHomeworkWebDto> DataDlh { get; set; }

}

