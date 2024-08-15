using System.Diagnostics;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Schedule.Application.Dto;
using Schedule.Application.Dto.WebDto;
using Schedule.Application.Exceptions;
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
        // todo когда буду делать авторизацию, необходимо запрашивать особые права для выполнения этого запроса
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

    public async Task<DateLessonsHomeworkWebDto> GetByDate(DateTime time)
    {
        // todo нужно переделать, т.к. вытасиквается вся БД, а нам нужно сначала отобрать нужные элементы, а потом уже их вытягивать из БД
        var allItemsFromDb = await _dbContext.Dates
            .Include(dlhDb => dlhDb.DataDlh)
            .FirstOrDefaultAsync(dlhDto => dlhDto.Day.Equals(time))
            ;
        if (allItemsFromDb == null)
        {
            throw new NotFoundException(nameof(DateLessonsHomeworkDb));
        }

        var dlhWeb = IMapWith.WebDto(_mapper, allItemsFromDb);
        return dlhWeb;
    }

    public async Task<DateLessonsHomeworkWebDto> Get(Guid guid)
    {
        var getItemFromDb = await _dbContext.Dates.Include(dlhDb => dlhDb.DataDlh)
            .FirstOrDefaultAsync(key => key.Id == guid);
        if (getItemFromDb == null || getItemFromDb.Id != guid)
        {
            throw new NotFoundException(nameof(DateLessonsHomeworkDb));
        }

        return IMapWith.WebDto(_mapper, getItemFromDb);
    }

    public async Task Update(DateLessonsHomeworkWebDto updateItem)
    {
        var updateItemDb = await _dbContext.Dates
            .FirstOrDefaultAsync(dlh => dlh.Id == updateItem.Id);
        if (updateItemDb == null || !updateItemDb.Id.Equals(updateItem.Id)) 
        {
            throw new NotFoundException(nameof(DateLessonsHomeworkDb));
        }

        var updatedItem = IMapWith.DbDto(_mapper, updateItem);
        updateItemDb.Day = updatedItem.Day; // todo ВОПРОС нужно как-то здесь поменять логику обновления 
        updateItemDb.DataDlh = updatedItem.DataDlh;
        _dbContext.Dates.Update(updateItemDb);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task Delete(Guid deleteId)
    {
        var deletedUser = await _dbContext.Dates
            .FirstOrDefaultAsync(dlh => dlh.Id.Equals(deleteId));
        if (deletedUser == null || !deletedUser.Id.Equals(deleteId))
        {
            throw new NotFoundException(nameof(DateLessonsHomeworkDb));
        }

        _dbContext.Dates.Remove(deletedUser);
        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }
}