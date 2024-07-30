using Microsoft.EntityFrameworkCore;
using Schedule.Application.Dto;

namespace Schedule.Application.Interfaces;

public interface IDateLessonsHomeworkDbContext
{
    DbSet<DateLessonsHomeworkDto> Dates { get; set; }
    DbSet<LessonHomeworkDto> Lessons { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}