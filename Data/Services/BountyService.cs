using Hackathon_2025_Filipino_Homes.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hackathon_2025_Filipino_Homes.Data.Services
{
    public class BountyService : IBountyService
    {
        private readonly HackathonContext _context;
        public BountyService(HackathonContext context) 
        {
            _context = context;
        }
        public async Task Add(Account account)
        {
            _context.bounty.Add(account.bounty);
            await _context.SaveChangesAsync();
            account.BountyId = account.bounty.Id;
            _context.account.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            var bounty = await _context.account.Include(u=> u.user).Include(b=> b.bounty).ToListAsync();
            return bounty;
        }


    }
}
