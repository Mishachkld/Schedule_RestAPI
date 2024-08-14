using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schedule.Application.Interfaces;

namespace Schedule.DataBase;

public static class DependenceInjection
{
    public static IServiceCollection AddProperties(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<ScheduleDbContext>(options =>
        {
            options.UseSqlite(connectionString);
            options.EnableSensitiveDataLogging();
        }); 
        services.AddScoped<IDateLessonsHomeworkDbContext>(provider => provider.GetService<ScheduleDbContext>());
        return services;
    }
}