using Schedule.Application.Dto.WebDto;

namespace Schedule.Application.Interfaces;

public interface IRepository
{
    public Task<List<DateLessonsHomeworkWebDto>> GetAll();
    public Task<List<DateLessonsHomeworkWebDto>> GetByDate(DateTime time);
    public Task<DateLessonsHomeworkWebDto> Get(Guid guid);
    public Task<Guid> AddAsync(DateLessonsHomeworkWebDto addItem);
    public void Update(DateLessonsHomeworkWebDto updateItem);
    public void Delete(DateLessonsHomeworkWebDto deleteItem);

}