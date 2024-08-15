using Microsoft.EntityFrameworkCore;

namespace Schedule.Test.Schedule;

public class GetScheduleUsingRepositoryTest : TestScheduleBase
{
    [Fact]
    public async void GetAllSchedule_Success()
    {
        //Act
        var allSchedule = await Repository.GetAll();

        //Assert
        Assert.True(allSchedule.Count == 4);
    }


    [Fact]
    public async void GetScheduleById_Success()
    {
        // Arrange
        var lessonNameFromSheduleFactory = "GetLesson 2";
        
        // Act
        var dayItem = await Repository.GetByDate(ScheduleRepositoryFactory.DateForGet);

        // Assert
        Assert.NotNull(await ContextDb.Dates.Include(schdl => schdl.DataDlh)
            .SingleOrDefaultAsync(shdl => shdl.Day.Equals(dayItem.Day)
                                          && null != shdl.DataDlh.SingleOrDefault(lh => lh.Lesson.Equals(lessonNameFromSheduleFactory))));
    }
}