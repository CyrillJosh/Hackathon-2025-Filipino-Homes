using Hackathon_2025_Filipino_Homes.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_2025_Filipino_Homes.Data
{
    public class HackathonContext : DbContext
    {
        public HackathonContext(DbContextOptions<HackathonContext> options)  : base(options){ }

        public DbSet<Bounty> bounty {get; set;}
        public DbSet<Account> account { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
