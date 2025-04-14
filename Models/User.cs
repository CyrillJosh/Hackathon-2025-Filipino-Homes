using System.ComponentModel.DataAnnotations;

namespace Hackathon_2025_Filipino_Homes.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage ="Firstname is required")]
        public string Firstname { get; set; } = null!;
        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; } = null!;
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        public int? AccountId { get; set; }
        public Account? account { get; set; }


    }
}
