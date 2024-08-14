using Schedule.Application.Interfaces;
using Schedule.Application.Schedule.VM;

namespace Schedule.Test;

public class TestScheduleBase
{
    protected IRepository Repository;
    protected IDateLessonsHomeworkDbContext ContextDb;

    public TestScheduleBase()
    {
        ContextDb = ScheduleRepositoryFactory.CreateDbContext();
        Repository = new ScheduleRepository(ContextDb, ScheduleRepositoryFactory.CreateMapper());

    }
    
}