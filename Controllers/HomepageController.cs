using Microsoft.AspNetCore.Mvc;

namespace Hackathon_2025_Filipino_Homes.Controllers
{
    public class HomepageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
