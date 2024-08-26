using System.ComponentModel.DataAnnotations;

namespace WebClient.Model
{
    public class Partners
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
