using Microsoft.EntityFrameworkCore;

namespace Schedule.Test.Schedule;

public class DeleteScheduleUsingRepositoryTest : TestScheduleBase
{
    [Fact]
    public async void DeleteSchedule_Success()
    {
        // Arrange
        var idDelete = ScheduleRepositoryFactory.IdForDelete;
        
        // Act
        await Repository.Delete(idDelete);

        // Assert
        Assert.Null(await ContextDb.Dates
            .SingleOrDefaultAsync(dlh => dlh.Id.Equals(idDelete)));
    }
}