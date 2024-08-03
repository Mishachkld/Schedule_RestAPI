using Microsoft.Extensions.DependencyInjection;
using Schedule.Application.Interfaces;
using Schedule.Application.Schedule.Mapper;
using Schedule.Application.Schedule.VM;

namespace Schedule.Application;

public static class DependenceInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRepository, ScheduleRepository>();
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new ScheduleDlhDtoMapperProfile()); 
            config.AddProfile(new ScheduleDlDtoMapperProfile()); 
            
        });

        return services;
    }
}