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
        public async Task Add(Bounty bounty)
        {

            _context.bounty.Add(bounty);
            await _context.SaveChangesAsync();
        }
         
        public async Task<IEnumerable<Bounty>> GetAll()
        {
            var bounty = await _context.bounty.Include(u=> u.account).ToListAsync();
            return bounty;
        }
    }
}
