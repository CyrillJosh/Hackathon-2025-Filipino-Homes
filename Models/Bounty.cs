using System.ComponentModel.DataAnnotations;

namespace Hackathon_2025_Filipino_Homes.Models
{
    public class Bounty
    {
        [Key]
        public string Id { get; set; } = new Guid().ToString();
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double reward { get; set; }

        public List<User>? User { get; set; }

    }
}
