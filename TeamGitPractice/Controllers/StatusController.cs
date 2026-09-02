using Microsoft.AspNetCore.Mvc;

namespace TeamGitPractice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStatus()
    {
        return Ok(new { status = "Running" });
    }
}
