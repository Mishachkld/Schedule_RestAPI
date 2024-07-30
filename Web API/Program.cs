using Schedule.Application.Dto;
using Schedule.DataBase;
using Web_API.EndPoint;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddProperties(config);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RestApiEndPoint.Map(app);
app.MapGet("/getDLH", () =>
{
    var date = DateTime.Today;
    return new DateLessonsHomeworkDto
    {
        Day = date,
        DataDLH = new List<LessonHomeworkDto>(new []
        {
            new LessonHomeworkDto{ Lesson = "NTF 404", Homework = "NTF 404"}
        })
    };
});
app.Run();