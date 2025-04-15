using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Hackathon_2025_Filipino_Homes.Controllers
{
    public class ChatController : Controller
    {
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
    }
}
