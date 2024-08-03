using Schedule.Application.Dto.WebDto;

namespace Schedule.Application.Interfaces;

public interface IRepository
{
    // TODO нужно ли делать эти методы async?
    public Task<List<DateLessonsHomeworkWebDto>> GetAll();
    public Task<Guid> AddAsync(DateLessonsHomeworkWebDto addItem); 
    public void Delete(DateLessonsHomeworkWebDto deleteItem);
    public void Update(DateLessonsHomeworkWebDto updateItem);
}