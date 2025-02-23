using Microsoft.AspNetCore.Mvc;

namespace AWS.Sample.API.Controllers;

public class HelloWorldController : ControllerBase
{
    [HttpGet]
    [Route("api/hello")]
    public IActionResult Get()
    {
        return Ok("Hello World!");
    }
}