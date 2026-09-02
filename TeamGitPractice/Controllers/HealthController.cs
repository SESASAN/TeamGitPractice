using Microsoft.AspNetCore.Mvc;

namespace TeamGitPractice.Controllers
{
    public class HealthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
