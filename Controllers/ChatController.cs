using Hackathon_2025_Filipino_Homes.Data;
using Hackathon_2025_Filipino_Homes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Hackathon_2025_Filipino_Homes.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly HackathonContext _context;


        public ChatController(HackathonContext context)
        {
            _context = context;
        }
        public IActionResult Private(string accountId)
        {
            var currentUserId = User.FindFirst("AccountId")?.Value;


            if (accountId == currentUserId)
            {
                return RedirectToAction("Index", "Home"); // can't chat with self
            }

            ViewBag.RecipientId = accountId;
            ViewBag.SenderId = currentUserId;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var myId = User.FindFirst("AccountId")?.Value;

            if (string.IsNullOrEmpty(myId))
                return Unauthorized();

            // Fetch conversations
            var conversations = await _context.Messages
                .Where(m => m.RecipientId == myId || m.SenderId == myId)
                .GroupBy(m => m.SenderId == myId ? m.RecipientId : m.SenderId)
                .Select(group => new ConversationModel
                {
                    OtherUserId = group.Key,
                    // Get the last message in the conversation
                    LastMessage = group.OrderByDescending(m => m.Timestamp).FirstOrDefault(),
                    // Fetch FirstName and LastName of the other user
                    OtherUserFirstName = _context.users
                        .Where(u => u.Id == group.Key)
                        .Select(u => u.Firstname)
                        .FirstOrDefault(),
                    OtherUserLastName = _context.users
                        .Where(u => u.Id == group.Key)
                        .Select(u => u.Lastname)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return View(conversations);
        }
    }
}
