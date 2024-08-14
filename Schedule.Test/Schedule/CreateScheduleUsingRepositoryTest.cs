using Microsoft.EntityFrameworkCore;
using Schedule.Application.Dto.WebDto;

namespace Schedule.Test.Schedule;

public class CreateScheduleUsingRepositoryTest : TestScheduleBase
{
    [Fact]
    public async void CreateSchedule_Success()
    {
        // Arange
        var day = DateTime.Today;
        var dataDlh = new List<LessonHomeworkWebDto>
        {
            new LessonHomeworkWebDto()
            {
                Lesson = "Lesson1",
                Homework = "HomeWork1",
                NumberLesson = 1
            }
        };

        //Act
        var guid = await Repository.AddAsync(new DateLessonsHomeworkWebDto
        {
            Day = day,
            DataDlh = dataDlh
        });

        // Assert
        Assert.NotNull(await ContextDb.Dates
            .SingleOrDefaultAsync(dlh =>
                dlh.Id.Equals(guid)
                && dlh.Day.Equals(day)));
    }
}