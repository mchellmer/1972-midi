using Microsoft.AspNetCore.Mvc;

namespace EightBitSaxLounge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(string detail, string title = "An error occurred")
    {
        return Problem(detail, title, 500);
    }
}