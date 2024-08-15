using Microsoft.AspNetCore.Mvc;
using Schedule.Application.Dto.WebDto;
using Schedule.Application.Interfaces;

namespace Web_API.Controllers;

[ApiController]
[Route("api/", Name = "Schedule REST API")]
public class ScheduleController : Controller
{
    private readonly IRepository _repository;
    public ScheduleController(IRepository repository) => _repository = repository;

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var elements = await _repository.GetAll();
        return Ok(elements);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] DateLessonsHomeworkWebDto requestItem)
    {
        var idItem = await _repository.AddAsync(requestItem);
        return Ok(idItem);
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get(DateTime date)
    {
        var itemByTime = await _repository.GetByDate(date);
        return Ok(itemByTime);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] DateLessonsHomeworkWebDto updateItem)
    {
        await _repository.Update(updateItem);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] Guid deleteUser)
    {
        await _repository.Delete(deleteUser);
        return NoContent();
    }

    
}