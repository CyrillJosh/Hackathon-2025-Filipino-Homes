using System.ComponentModel.DataAnnotations;

namespace Hackathon_2025_Filipino_Homes.Models
{
    public class Bounty
    {
        [Key]
        public string Id { get; set; } = new Guid().ToString();
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Reward is required")]
        public double reward { get; set; }

        public List<User>? User { get; set; }

    }
}
