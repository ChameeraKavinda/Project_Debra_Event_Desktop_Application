using System.ComponentModel.DataAnnotations;

namespace DebraAPI.DTO
{
    public class DebraAdminCreateDTO
    {
        [Required]

        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; } = string.Empty;
    }
}
