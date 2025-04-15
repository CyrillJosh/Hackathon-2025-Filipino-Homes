using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon_2025_Filipino_Homes.Models
{
    public class Bounty
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Reward is required")]
        public double reward { get; set; }
        public bool status { get; set; } = false;
        public string? AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account? account { get; set; }   
    }
}
