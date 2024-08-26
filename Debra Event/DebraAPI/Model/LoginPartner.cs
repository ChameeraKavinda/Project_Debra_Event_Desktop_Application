using System.ComponentModel.DataAnnotations;

namespace DebraAPI.Model
{
    public class LoginPartner
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }= string.Empty;
    }
}
