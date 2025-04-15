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
            string? currentUserId = User.FindFirstValue("AccountId");
            ViewBag.CurrentUserId = currentUserId;
            var bounty = await _bountyService.GetAll();
            return View(bounty);
        }
        [Authorize]
        public IActionResult Create(string id)
        {
            var bounty = new Bounty
            {
                AccountId = id,
            };
            return View(bounty);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProcess([Bind("AccountId, Title, Description, reward")] Bounty bounty)
        {
            string? currentUserId = User.FindFirstValue("AccountId");

            if (currentUserId == null)
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View("Create", "Bounty");
            }
            await _bountyService.Add(bounty);
            return RedirectToAction("Home", "Bounty");
        }
    }
}
