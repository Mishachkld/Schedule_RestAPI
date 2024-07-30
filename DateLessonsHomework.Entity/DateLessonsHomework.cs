namespace DateLessonsHomework.Entity;

public class DateLessonsHomework
{
    public Guid Id { get; set; }
    public DateTime Day { get; set; }
    public List<LessonHomework> DataDLH { get; set; }
}