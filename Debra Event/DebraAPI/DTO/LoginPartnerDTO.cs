using System.ComponentModel.DataAnnotations;

namespace DebraAPI.DTO
{
    public class LoginPartnerDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
