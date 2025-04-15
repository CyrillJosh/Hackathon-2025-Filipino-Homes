using Microsoft.AspNetCore.SignalR;

namespace Hackathon_2025_Filipino_Homes.Models
{
    public class CustomerIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst("AccountId")?.Value;
        }
    }
}
