using Microsoft.EntityFrameworkCore;
using Schedule.Application.Dto;
using Schedule.Application.Dto.WebDto;

namespace Schedule.Test.Schedule;

public class UpdateScheduleUsingRepositoryTest : TestScheduleBase
{
    [Fact]
    public async void UpdateSchedule_Success()
    {
        // Arrange
        var lessonName = "Updated Lesson 2";
        var updateScheduleObject = new DateLessonsHomeworkWebDto()
        {
            Id = ScheduleRepositoryFactory.IdForUpdate,
            Day = DateTime.Today,
            DataDlh = new List<LessonHomeworkWebDto>()
            {
                new LessonHomeworkWebDto()
                {
                    Lesson = lessonName,
                    Homework = "HomeWork 2",
                    NumberLesson = 2
                },
                new LessonHomeworkWebDto()
                {
                    Lesson = "Updated Lesson 3",
                    Homework = "HomeWork 3",
                    NumberLesson = 3
                },
                new LessonHomeworkWebDto()
                {
                    Lesson = "Updated Lesson 4",
                    Homework = "HomeWork 4",
                    NumberLesson = 4
                }
            }
        };

        // Act
        await Repository.Update(updateScheduleObject);

        // Assert
        Assert.NotNull(await ContextDb.Dates.Include(shdl => shdl.DataDlh)
            .SingleOrDefaultAsync(dlhDb => dlhDb.Id == ScheduleRepositoryFactory.IdForUpdate
                                           && dlhDb.DataDlh
                                               .SingleOrDefault(lh => lh.Lesson.Equals(lessonName)) != null));
    }
}