using Hackathon_2025_Filipino_Homes.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace Hackathon_2025_Filipino_Homes.Models
{
    [Authorize]
    public class ChatHub : Hub
    {
        private static ConcurrentDictionary<string, string> _userConnections = new ConcurrentDictionary<string, string>();
        private readonly HackathonContext _context;

        public ChatHub(HackathonContext context)
        {
            _context = context;
        }

        public override Task OnConnectedAsync()
        {
            var userId = Context.User.FindFirst("AccountId")?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                _userConnections[userId] = Context.ConnectionId;
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.User.FindFirst("AccountId")?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                _userConnections.TryRemove(userId, out _);
            }
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string recipientUserId, string message)
        {
            var senderUserId = Context.User.FindFirst("AccountId")?.Value;

            if (string.IsNullOrWhiteSpace(senderUserId) || string.IsNullOrWhiteSpace(recipientUserId))
                return;

            var chatMessage = new Message
            {
                SenderId = senderUserId,
                RecipientId = recipientUserId,
                Content = message,
                Timestamp = DateTime.UtcNow
            };

            _context.Messages.Add(chatMessage);
            await _context.SaveChangesAsync();

            await Clients.User(recipientUserId).SendAsync("ReceiveMessage", senderUserId, message);
            await Clients.User(senderUserId).SendAsync("ReceiveMessage", senderUserId, message);
        }

        public async Task<List<object>> GetChatHistory(string withUserId)
        {
            var myId = Context.User.FindFirst("AccountId")?.Value;

            if (string.IsNullOrEmpty(myId) || string.IsNullOrEmpty(withUserId))
            {
                return new List<object>(); // Return an empty list if user ID or recipient ID is not valid
            }

            var history = await _context.Messages
                .Where(m => (m.SenderId == myId && m.RecipientId == withUserId) ||
                            (m.SenderId == withUserId && m.RecipientId == myId))
                .OrderBy(m => m.Timestamp)
                .Select(m => new
                {
                    senderId = m.SenderId,
                    content = m.Content,
                    timestamp = m.Timestamp
                })
                .Cast<object>() 
                .ToListAsync();

            return history;
        }
    }

}
