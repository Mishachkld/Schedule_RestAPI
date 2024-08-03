using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schedule.Application.Dto;
using Schedule.Application.Dto.WebDto;
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
                // TODO убрать это из класса и переделать отправку, используя DateLessonHomeworkWebDto
                var list = await dbContext.Dates
                    .Include(dateLessonsHomeworkDto => dateLessonsHomeworkDto.DataDlh)
                    .Select(dth => new
                    {
                        dth.Id,
                        dth.Day,
                        LessonHomeworkDto = dth.DataDlh
                            .Select(lh => new
                            {
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
            async (HttpContext context, [FromBody] DateLessonsHomeworkDto dlhFromPost,
                IDateLessonsHomeworkDbContext dbContext) =>
            {
                var date = new DateLessonsHomeworkDto // TODO 
                {
                    Day = DateTime.Today,
                    DataDlh = dlhFromPost.DataDlh
                };
                await dbContext.Dates.AddAsync(date);
                await dbContext.SaveChangesAsync(CancellationToken.None);
                await context.Response.WriteAsJsonAsync(date.Id);
            });
    }
}