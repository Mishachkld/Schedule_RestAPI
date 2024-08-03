using Schedule.Application.Dto.WebDto;

namespace Schedule.Application.Interfaces;

public interface IRepository
{
    public Task<List<DateLessonsHomeworkWebDto>> GetAll();
    public Task<Guid> AddAsync(DateLessonsHomeworkWebDto addItem);
    public void Delete(DateLessonsHomeworkWebDto deleteItem);
    public Task<List<DateLessonsHomeworkWebDto>> GetByDate(DateTime time);
    public Task<DateLessonsHomeworkWebDto> Get(Guid guid);
    public void Update(DateLessonsHomeworkWebDto updateItem);
}