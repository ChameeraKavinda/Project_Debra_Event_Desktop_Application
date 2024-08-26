using System.ComponentModel.DataAnnotations;

namespace DebraAPI.Model
{
    public class LoginDebraAdmin
    {
        [Required]
        public string AdminEmail { get; set; }
        [Required]
        public string AdminPassword { get; set; } = string.Empty;
    }
}
