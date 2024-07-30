using Microsoft.EntityFrameworkCore;
using Schedule.Application.Interfaces;
using Schedule.DataBase.Configuration;
using DateLessonsHomework.Entity;
using Schedule.Application.Dto;

namespace Schedule.DataBase;

public class DateLessonHomeworkDbContext : DbContext, IDateLessonsHomeworkDbContext
{
    public DbSet<DateLessonsHomeworkDto> Dates { get; set; }
    public DbSet<LessonHomeworkDto> Lessons { get; set; }

    public DateLessonHomeworkDbContext(DbContextOptions<DateLessonHomeworkDbContext> configuration) : base(
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