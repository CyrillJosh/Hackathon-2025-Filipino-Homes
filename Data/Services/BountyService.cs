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
        public async Task<IEnumerable<Account>> GetAll()
        {
            var bounty = await _context.account.ToListAsync();
            return bounty;
        }


    }
}
