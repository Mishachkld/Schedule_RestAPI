using Microsoft.EntityFrameworkCore;
using Schedule.Application.Interfaces;
using Schedule.DataBase.Configuration;
using DateLessonsHomework.Entity;
using Schedule.Application.Dto;

namespace Schedule.DataBase;

public class ScheduleDbContext : DbContext, IDateLessonsHomeworkDbContext
{
    public DbSet<DateLessonsHomeworkDb> Dates { get; set; }
    public DbSet<LessonHomeworkDb> Lessons { get; set; }

    public ScheduleDbContext(DbContextOptions<ScheduleDbContext> configuration) : base(
        configuration)
    {
        Database.EnsureCreated(); 
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DateLessonsHomeworkConfiguration());
        modelBuilder.ApplyConfiguration(new LessonHomeworkConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}