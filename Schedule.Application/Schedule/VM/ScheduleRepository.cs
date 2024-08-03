using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Schedule.Application.Dto.WebDto;
using Schedule.Application.Interfaces;
using Schedule.Application.Schedule.Mapper;

namespace Schedule.Application.Schedule.VM;

public class ScheduleRepository : IRepository
{
    private readonly IDateLessonsHomeworkDbContext _dbContext;
    private IMapper _mapper;

    public ScheduleRepository(IDateLessonsHomeworkDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<DateLessonsHomeworkWebDto>> GetAll()
    {
        var listOfDateFromDb = await _dbContext.Dates.Include(dateLessonsHomeworkDto => dateLessonsHomeworkDto.DataDlh)
            .ToListAsync();
        
        return IMapWith.WebDtoList(_mapper, listOfDateFromDb);
    }

    public async Task<Guid> AddAsync(DateLessonsHomeworkWebDto addItem)
    {
        addItem.Day = DateTime.Today;
        var dbEntity = IMapWith.DbDto(_mapper, addItem);
        await _dbContext.Dates.AddAsync(dbEntity);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
        return dbEntity.Id;
    }

    public void Delete(DateLessonsHomeworkWebDto deleteItem)
    {
        // TODO
    }

    public void Update(DateLessonsHomeworkWebDto updateItem)
    {
        // TODO

    }
}