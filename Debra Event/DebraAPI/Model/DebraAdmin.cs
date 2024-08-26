using System.ComponentModel.DataAnnotations;

namespace DebraAPI.Model
{
    public class DebraAdmin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]

        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; } = string.Empty;

    }
}
