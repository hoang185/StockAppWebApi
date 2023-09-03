using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace StockAppWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }
    
    private static readonly List<TodoItem> _items = new List<TodoItem>
        {
            new TodoItem { Id = 1, Name = "Learn ASP.NET Core", IsComplete = false },
            new TodoItem { Id = 2, Name = "Build a web API", IsComplete = false },
            new TodoItem { Id = 3, Name = "Test it with Postman", IsComplete = true }
        };

    // GET: api/Todo
    [HttpGet]
    public ActionResult<IEnumerable<TodoItem>> Get()
    {
        return _items;
    }

    // GET: api/Todo/1
    [HttpGet("{id}")]
    public ActionResult<TodoItem> Get(int id)
    {
        var item = _items.Find(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return item;
    }
    [HttpGet("hello")]
    public IActionResult SayHello()
    {
        return Ok("hello cc");
    }
}
