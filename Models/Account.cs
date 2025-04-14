using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Hackathon_2025_Filipino_Homes.Models
{
    public class Account
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Lastname is required")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? user { get; set; }
        public string? BountyId { get; set; }
        [ForeignKey("BountyId")]
        public Bounty? bounty { get; set; }
    }
}
