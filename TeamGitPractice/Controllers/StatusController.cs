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

    [HttpGet("team")]
    public IActionResult GetTeamStatus()
    {
        return Ok(new { team = "Deploy Enjoyers", status = "Ready" });
    }
}
