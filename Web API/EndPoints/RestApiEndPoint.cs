using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Schedule.Application.Dto;
using Schedule.Application.Interfaces;
using Schedule.DataBase;

namespace Web_API.EndPoint;

public class RestApiEndPoint
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/getall",
            async (HttpContext context, DateLessonHomeworkDbContext dbContext) =>
            {
                var list = await dbContext.Dates
                    .Include(dateLessonsHomeworkDto => dateLessonsHomeworkDto.DataDLH)
                    .Select(dth => new
                    {
                        dth.Id,
                        LessonHomeworkDto = dth.DataDLH
                            .Select(lh => new {
                                lh.DateId,
                                lh.Lesson,
                                lh.Homework,
                                lh.NumberLesson
                            }).ToList()
                    }).ToListAsync();
                await context.Response.WriteAsJsonAsync(list);
            });

        app.MapGet("/{id}", async context =>
        {
            // Get one todo item
            await context.Response.WriteAsJsonAsync(new { Message = "One todo item" });
        });

        app.MapPost("/add",
            async (HttpContext context, DateLessonsHomeworkDto dlhFromPost, IDateLessonsHomeworkDbContext dbContext) =>
            {
                var dlh = new DateLessonsHomeworkDto
                {
                    Day = DateTime.Today,
                    DataDLH = dlhFromPost.DataDLH
                };
                await dbContext.Dates.AddRangeAsync(dlh);
                await dbContext.SaveChangesAsync(CancellationToken.None);
                await context.Response.WriteAsJsonAsync(dlh.Id);
            });
    }
}