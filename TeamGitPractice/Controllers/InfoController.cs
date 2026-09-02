using Microsoft.AspNetCore.Mvc;

namespace TeamGitPractice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InfoController : ControllerBase
{
    [HttpGet]
    public IActionResult GetInfo()
    {
        return Ok(new { description = "Práctica colaborativa con Git" });
    }

    [HttpGet("tools")]
    public IActionResult GetTools()
    {
        var tools = new[] { "Git", "GitHub", "Visual Studio Community 2026" };
        return Ok(tools);
    }
}