using Hackathon_2025_Filipino_Homes.Models;

namespace Hackathon_2025_Filipino_Homes.Data.Services
{
    public interface IAuthService
    {
        Task<bool> UserAccount(string username, string password);
        Task Add(Account account);
        string HashPassword(string password);
    }
}
