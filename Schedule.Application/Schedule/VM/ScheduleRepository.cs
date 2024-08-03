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

    public async Task<List<DateLessonsHomeworkWebDto>> GetByDate(DateTime time)
    {
        // todo нужно переделать, т.к. вытасиквается вся БД, а нам нужно сначала отобрать нужные элементы, а потом уже их вытягивать из БД
        var allItemsFromDb = await _dbContext.Dates.Include(dlhDb => dlhDb.DataDlh)
            .ToListAsync();
        var getItemsFromDb = allItemsFromDb.FindAll(key => key.Day == time);
        List<DateLessonsHomeworkWebDto> dlhWeb = null;
        if (getItemsFromDb != null)
        {
            dlhWeb = IMapWith.WebDtoList(_mapper, getItemsFromDb);
        }

        return dlhWeb;
    }

    public async Task<DateLessonsHomeworkWebDto> Get(Guid guid)
    {
        var getItemFromDb = await _dbContext.Dates.Include(dlhDb => dlhDb.DataDlh)
            .FirstOrDefaultAsync(key => key.Id == guid);

        return IMapWith.WebDto(_mapper, getItemFromDb);
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