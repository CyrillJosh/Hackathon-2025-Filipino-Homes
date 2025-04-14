using Hackathon_2025_Filipino_Homes.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Hackathon_2025_Filipino_Homes.Data.Services
{
    public class AuthService : IAuthService
    {
        private readonly HackathonContext _context;

        public AuthService(HackathonContext context)
        {
            _context = context;
        }

        //Adding Account
        public async Task Add(Account account)
        {
            _context.users.Add(account.user);
            await _context.SaveChangesAsync();

            account.UserId = account.user.Id;
            account.user.AccountId = account.UserId;
            _context.account.Add(account);
            await _context.SaveChangesAsync();
        }

        //Hashing
        public string HashPassword(string password)
        {
            return Convert.ToBase64String(
               System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password))
               );
        }

        //Checking if exist
        public async Task<bool> UserAccount(string username, string password)
        {
            return await _context.account.AnyAsync(u => u.Username == username && u.Password == password);
        }
    }
}
