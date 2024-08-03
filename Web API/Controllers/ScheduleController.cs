using Microsoft.AspNetCore.Mvc;
using Schedule.Application.Dto.WebDto;
using Schedule.Application.Interfaces;

namespace Web_API.Controllers;
[ApiController]
[Route("api/[action]")]
public class ScheduleController : Controller
{
    private readonly IRepository _repository;
    public ScheduleController(IRepository repository) => _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var elements = await _repository.GetAll();
        if (elements != null && elements.Count != 0)
        {
            return Ok(elements);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] DateLessonsHomeworkWebDto requestItem)
    {
        var idItem = await _repository.AddAsync(requestItem);
        return Ok(idItem);
    }
    
}