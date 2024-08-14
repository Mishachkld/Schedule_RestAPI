using Microsoft.EntityFrameworkCore;
using Schedule.Application.Dto;

namespace Schedule.Application.Interfaces;

public interface IDateLessonsHomeworkDbContext
{
    DbSet<DateLessonsHomeworkDb> Dates { get; set; }
    DbSet<LessonHomeworkDb> Lessons { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}