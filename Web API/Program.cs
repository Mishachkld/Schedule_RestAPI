using System.Diagnostics;
using Schedule.Application;
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

services.AddControllers();
services.AddProperties(config);
services.AddApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Это позволит использовать атрибуты маршрутизации в контроллерах
});
// TODO нам нужен маршрут по типу localhost:5315/api/ и тут уже смотреть на запрос, какой он: GET POST и т.д.
// RestApiEndPoint.Map(app);
app.Run();