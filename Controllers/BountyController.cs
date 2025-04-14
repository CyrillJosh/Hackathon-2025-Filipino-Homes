using Hackathon_2025_Filipino_Homes.Data.Services;
using Hackathon_2025_Filipino_Homes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

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
            string? currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.CurrentUserId = currentUserId;
            var bounty = await _bountyService.GetAll();
            return View(bounty);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProcess([Bind("account, Title, Description, Reward")]Bounty bounty)
        {
            if (ModelState.IsValid)
            {
                await _bountyService.Add(bounty);
                return RedirectToAction("Home", "Bounty");
            }
            return View("Create");
        }
    }
}
