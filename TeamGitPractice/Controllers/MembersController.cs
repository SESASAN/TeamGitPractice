using Microsoft.AspNetCore.Mvc;

namespace TeamGitPractice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMembers()
    {
        var members = new[]
        {
        "NOMBRE COMPLETO 1",
        "NOMBRE COMPLETO 2",
        "NOMBRE COMPLETO 3",
        "NOMBRE COMPLETO 4",
        "NOMBRE COMPLETO 5"
        };
        return Ok(members);
    }
}