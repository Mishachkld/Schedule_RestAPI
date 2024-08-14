using Microsoft.AspNetCore.Mvc;
using Schedule.Application.Dto.WebDto;
using Schedule.Application.Interfaces;

namespace Web_API.EndPoints;

public class RestApiEndPoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/getall",
            async (HttpContext context, IRepository repository) =>
            {
                var list = await repository.GetAll();
                await context.Response.WriteAsJsonAsync(list);
            });

        app.MapGet("/{id}", async (HttpContext context, IRepository repository, Guid id) =>
        {
            var getItemById = await repository.Get(id);
            await context.Response.WriteAsJsonAsync(getItemById);
        });

        app.MapPost("/add",
            async (HttpContext context, [FromBody] DateLessonsHomeworkWebDto dlhFromPost,
                IRepository repository) =>
            {   // TODO как здесь отлавливать ошибки? Через middleware?
                // Exception: Microsoft.AspNetCore.Http.BadHttpRequestException
                var addedItem = await repository.AddAsync(dlhFromPost);
                await context.Response.WriteAsJsonAsync(addedItem);
            });
    }
}