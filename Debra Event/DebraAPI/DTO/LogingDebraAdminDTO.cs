using System.ComponentModel.DataAnnotations;

namespace DebraAPI.DTO
{
    public class LogingDebraAdminDTO
    {
        [Required]
        public string AdminEmail { get; set; }
        [Required]
        public string AdminPassword { get; set; } = string.Empty;
    }
}
