using Microsoft.AspNetCore.Mvc;

namespace TeamGitPractice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VersionController : ControllerBase
{
    [HttpGet]
    public IActionResult GetVersion() 
    { 
        return Ok(new{ version = "1.0.0" });
    }    

    [HttpGet("platform")]
    public IActionResult GetPlatform()
    {
        return Ok(new { platform = ".Net 10", project = "TeamGitPractice" });
    }
}
