using Hackathon_2025_Filipino_Homes.Data.Services;
using Hackathon_2025_Filipino_Homes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hackathon_2025_Filipino_Homes.Controllers
{
    public class BountyController : Controller
    {

        private readonly IBountyService _bountyService;
        public BountyController(IBountyService bountyService)
        {
            _bountyService = bountyService;
        }
        [Authorize]
        public async Task<IActionResult> Home()
        {
            var bounty = await _bountyService.GetAll();
            return View(bounty);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProcess(Account account)
        {
            if (ModelState.IsValid)
            {
                await _bountyService.Add(account);
                return RedirectToAction("Index", "Bounty");
            }
            return View();
        }
    }
}
