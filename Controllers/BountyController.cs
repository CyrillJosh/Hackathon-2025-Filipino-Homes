using Hackathon_2025_Filipino_Homes.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_2025_Filipino_Homes.Controllers
{
    public class BountyController : Controller
    {
        private readonly IBountyService _bountyService;
        public BountyController(IBountyService bountyService)
        {
            _bountyService = bountyService;
        }
        public async Task<IActionResult> Home()
        {
            var bounty = await _bountyService.GetAll();
            return View(bounty);
        }
    }
}
