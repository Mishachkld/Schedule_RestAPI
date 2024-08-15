using Schedule.Application.Dto.WebDto;

namespace Schedule.Application.Interfaces;

public interface IRepository
{
    public Task<List<DateLessonsHomeworkWebDto>> GetAll();
    public Task<DateLessonsHomeworkWebDto> GetByDate(DateTime time);
    public Task<DateLessonsHomeworkWebDto> Get(Guid guid);
    public Task<Guid> AddAsync(DateLessonsHomeworkWebDto addItem);
    public Task Update(DateLessonsHomeworkWebDto updateItem);
    public Task Delete(Guid deleteItem);

}